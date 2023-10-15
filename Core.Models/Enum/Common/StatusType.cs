namespace Core.Models.Enum.Common
{
    public enum StatusType
    {
        Active = 1,
        DeActive,
        Deleted,
        WaitForConfirm,
        WaitForGetCoordinate,
        WaitForCreateAccount,
        WaitForConfirmAccount,
        PreOrder,
        Inquiring,
        DoneInquiry,
        Paid,
        Delivered,
        UnDelivered,
        Final,
        Open,
        Close,
    }
}