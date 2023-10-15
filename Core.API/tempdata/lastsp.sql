SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Mohsen Zeinali>
-- Create date: <1400/07/05>
-- Description:	<get all user complete cart>
-- =============================================
ALTER PROCEDURE [Business].[sp_GetAllUserCompleteCart]
    @UserId INT,
    @PageNumber INT = 1,
    @PageRecord INT = 2147483647
AS
BEGIN

    --Default order values
    IF (@PageNumber IS NULL OR @PageNumber = 0)
        SET @PageNumber = 1;
    IF (@PageRecord IS NULL OR @PageRecord = 0)
        SET @PageRecord = 2147483647;

    --calc skip for get data
    DECLARE @Skip INT = (@PageNumber - 1) * @PageRecord;

    --get data
    SELECT tc.Id,
           tua.FirstName,
           tua.LastName,
           tua.MobileNumber,
           tc.ProductPrice,
           tc.DeliveryPrice,
           tc.LastStatusId,
           tcsr.CreatedOn,
           tp.TransactionCode
    FROM Business.tbCart AS tc
        INNER JOIN [Security].tbUserAddress AS tua
            ON tua.Id = tc.UserAddressId
        INNER JOIN Business.tbCartStatusRow AS tcsr
            ON tcsr.CartId = tc.Id
               AND tcsr.[Row] = 1
        INNER JOIN Parbad.tbPayment AS tp
            ON tp.TrackingNumber = tc.TrackingNumber
    WHERE tc.LastStatusId IN ( 11, 14 )
    ORDER BY tc.Id DESC OFFSET (@Skip) ROWS FETCH NEXT (@PageRecord) ROWS ONLY;

    --get record count
    SELECT COUNT(1) TotalCount
    FROM Business.tbCart AS tc
    WHERE tc.UserId = @UserId
          AND tc.LastStatusId IN ( 11, 14 );

END;
GO
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Mohsen Zeinali>
-- Create date: <1400/08/05>
-- Description:	<get user complete cart info>
-- =============================================
ALTER PROCEDURE [Business].[sp_GetUserCompleteCartInfo]
    @CartId INT,
    @UserId INT
AS
BEGIN

    --در صورت وجود نداشتن دسترسی برگشت داده شود
    IF NOT EXISTS
    (
        SELECT 1
        FROM Business.tbCart AS tc
        WHERE tc.Id = @CartId
              AND tc.UserId = @UserId
              AND tc.LastStatusId IN ( 11, 14 )
    )
        RETURN;

    -- لیست محصولات سبد خرید
    SELECT tp.Id ProductId,
           tp.Code ProductCode,
           tp.[Name] ProductName,
           tcpr.Quantity,
           tcpr.Price Price,
           tcpr.DiscountPrice Discount,
           tcpr.Quantity * (CASE
                                WHEN tcpr.DiscountPrice IS NOT NULL THEN
           (tcpr.Price) - (tcpr.DiscountPrice)
                                ELSE
                                    tcpr.Price
                            END
                           ) FinalPrice,
           tpppr.CdnFileId
    FROM Business.tbCartProduct AS tcpr
        INNER JOIN Business.tbProduct AS tp
            ON tp.Id = tcpr.ProductId
        LEFT JOIN Business.tbProductPhotoRow tpppr
            ON tpppr.ProductId = tp.Id
               AND tpppr.[Row] = 1
    WHERE tcpr.CartId = @CartId;

    --نمایش اطلاعات سبد خرید
    SELECT TOP 1
           tua.[Address],
           tcy.[Name] CityName,
           tpe.[Name] ProvinceName,
           td.[Name] DistrictName,
           tua.Latitudes,
           tua.Longitudes,
           tua.ZipCode,
           tua.HouseNumber,
           tua.HouseUnit,
           tpc.Title PostalCodeTitle,
           tcdt.Title CartDeliveryTypeTitle,
           tcdpt.Title CartDeliveryPlaceTypeTitle,
           tcfdt.Title CartFailedDeliveryTypeTitle,
           tc.TomorrowDeliveryOn,
           tc.DailyDeliveryStartOn,
           tc.DailyDeliveryEndOn
    FROM Business.tbCart AS tc
        INNER JOIN Security.tbUserAddress AS tua
            ON tua.Id = tc.UserAddressId
        INNER JOIN Base.tbCity AS tcy
            ON tcy.Id = tua.CityId
        INNER JOIN Base.tbProvince AS tpe
            ON tpe.Id = tua.ProvinceId
        INNER JOIN Base.tbDistrict AS td
            ON td.Id = tua.DistrictId
        LEFT JOIN Business.tbPostalCart AS tpc
            ON tpc.Id = tc.PostalCartId
        INNER JOIN Business.tbCartDeliveryType AS tcdt
            ON tcdt.Id = tc.CartDeliveryTypeId
        INNER JOIN Business.tbCartDeliveryPlaceType AS tcdpt
            ON tcdpt.Id = tc.CartDeliveryPlaceTypeId
        INNER JOIN Business.tbCartFailedDeliveryType AS tcfdt
            ON tcfdt.Id = tc.CartFailedDeliveryTypeId
    WHERE tc.Id = @CartId;

END;
GO


