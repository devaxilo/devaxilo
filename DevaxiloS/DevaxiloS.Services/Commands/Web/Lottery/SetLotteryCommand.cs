using System;
using System.Linq;
using System.Threading.Tasks;
using DevaxiloS.DataAccess.MsSql.EntityFramework;
using DevaxiloS.Infras.Commands;
using DevaxiloS.Infras.Common.Enums;
using DevaxiloS.Infras.Common.Extension;
using DevaxiloS.Infras.Messaging;
using DevaxiloS.Services.DomainModels.Lottery;

namespace DevaxiloS.Services.Commands.Web.Lottery
{
    public class SetLotteryCommand : Command
    {
        public SetLotteryRequest Request { get; }

        public CommandResponse<bool> Response { get; set; }

        public SetLotteryCommand(int id, SetLotteryRequest request) : base(id)
        {
            Request = request;
        }
    }

    public class SetLotteryCommandHandler : ICommandHandler<SetLotteryCommand>
    {
        public async Task Execute(SetLotteryCommand command)
        {
            var request = command.Request;

            var dnow = DateTime.UtcNow;

            if (!dnow.CanJoinLottery())
            {
                command.Response = new CommandResponse<bool>(false, true, "Bạn không thể đánh vào giờ này!");
                return;
            }

            using (var context = new DevaxiloContext())
            {
                var currentBalance = context.AccountBalances.FirstOrDefault(x => x.AccId == request.UserId);
                var totalAmount = request.Numbers.Length * request.Amount;
                if (currentBalance != null && currentBalance.Balance >= totalAmount)
                {
                    using (var trans = context.Database.BeginTransaction())
                    {
                        foreach (var number in request.Numbers)
                        {
                            var lottery = new LotteryTransaction
                            {
                                UUID = Guid.NewGuid(),
                                UserId = request.UserId,
                                LotteryNumber = number,
                                Amount = request.Amount,
                                CreatedAt = dnow,
                                LotteryType = (byte) request.LotteryType,
                                WalletType = (byte) request.WalletType,
                                TransactionType = (byte) LotteryTransactionType.Set,
                                Status = (byte) LotteryTransactionStatus.Processing
                            };

                            context.LotteryTransactions.Add(lottery);
                        }

                        currentBalance.Balance -= totalAmount;
                        currentBalance.HoldBalance += totalAmount;
                        await context.SaveChangesAsync();
                        trans.Commit();
                        command.Response = new CommandResponse<bool>(true, false, "Đánh thành công");
                    }
                    return;
                }

                command.Response = new CommandResponse<bool>(false, true, "Tài khoản của bạn không đủ số dư!");
            }
        }
    }
}
