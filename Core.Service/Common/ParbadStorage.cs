using Core.DataContract;
using Core.Models.Parameter.Common.ParbadStorage;
using Core.Models.ViewModel.Common.ParbadStorage;
using Parbad.Storage.Abstractions;
using Parbad.Storage.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Service.Common
{
    public class ParbadStorage : IStorage
    {
        private readonly IRepository _repository;

        public ParbadStorage(IRepository repository)
        {
            _repository = repository;
        }

        private static IList<Payment> StaticPayments = new List<Payment>();
        private static IList<Transaction> StaticTransactions = new List<Transaction>();

        public Task CreatePaymentAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            var paymentId = _repository.Sp_AddPayment(new AddPaymentParam
            {
                TrackingNumber = payment.TrackingNumber,
                Amount = payment.Amount,
                Token = payment.Token,
                TransactionCode = payment.TransactionCode,
                GatewayName = payment.GatewayName,
                GatewayAccountName = payment.GatewayAccountName,
                IsCompleted = payment.IsCompleted,
                IsPaid = payment.IsPaid
            }).Result;

            payment.Id = paymentId;

            LoadStaticData();

            return Task.CompletedTask;
        }

        public Task UpdatePaymentAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            var record = GetPaymentByIdAsync((int)payment.Id).Result;

            if (record == null) throw new Exception();

             _repository.Sp_UpdatePayment(new UpdatePaymentParam
            {
                Id = (int)payment.Id,
                TrackingNumber = payment.TrackingNumber,
                Token = payment.Token,
                TransactionCode = payment.TransactionCode,
                GatewayAccountName = payment.GatewayAccountName
            }).GetAwaiter().GetResult();

            LoadStaticData();

            return Task.CompletedTask;
        }

        public Task DeletePaymentAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            var record = GetPaymentByIdAsync((int)payment.Id).Result;

            if (record == null) throw new Exception();

            _repository.Sp_DeletePayment(new DeletePaymentParam{ Id = (int)payment.Id }).GetAwaiter().GetResult();
;
            LoadStaticData();

            return Task.CompletedTask;
        }

        public Task CreateTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            var transactionId = _repository.Sp_AddTransaction(new AddTransactionParam
            {
                Amount = transaction.Amount,
                Type = (int)transaction.Type,
                IsSucceed = transaction.IsSucceed,
                Message = transaction.Message,
                AdditionalData = transaction.AdditionalData,
                PaymentId = (int)transaction.PaymentId
            }).Result;

            transaction.Id = transactionId;

            LoadStaticData();

            return Task.CompletedTask;
        }

        public Task UpdateTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            var record = GetTransactionByIdAsync((int)transaction.Id).Result;

            if (record == null) throw new Exception();

            _repository.Sp_UpdateTransaction(new UpdateTransactionParam
            {
                Id = (int)transaction.Id,
                IsSucceed = transaction.IsSucceed
            }).GetAwaiter().GetResult();

            LoadStaticData();

            return Task.CompletedTask;
        }

        public Task DeleteTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            var record = GetTransactionByIdAsync((int)transaction.Id).Result;

            if (record == null) throw new Exception();

            _repository.Sp_DeleteTransaction(new DeleteTransactionParam { Id = (int)transaction.Id }).GetAwaiter().GetResult();

            LoadStaticData();

            return Task.CompletedTask;
        }

        private Task<GetPaymentByIdVm> GetPaymentByIdAsync(int id)
        {
            var results = _repository.Sp_GetPaymentById(new GetPaymentByIdParam { Id = id }).Result;

            LoadStaticData();

            return Task.FromResult(results);
        }

        private Task<GetTransactionByIdVm> GetTransactionByIdAsync(int id)
        {
            var results = _repository.Sp_GetTransactionById(new GetTransactionByIdParam { Id = id }).Result;

            LoadStaticData();

            return Task.FromResult(results);
        }

        private Task LoadStaticData()
        {
            StaticPayments = _repository.Sp_GetAllPayment().Result.ToList();
            StaticTransactions = _repository.Sp_GetAllTransaction().Result.ToList();

            return Task.CompletedTask;
        }

        public IQueryable<Payment> Payments => StaticPayments.AsQueryable();

        public IQueryable<Transaction> Transactions => StaticTransactions.AsQueryable();
    }
}
