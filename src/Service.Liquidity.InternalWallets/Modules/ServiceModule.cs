using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using MyJetWallet.Sdk.NoSql;
using Service.Balances.Client;
using Service.Liquidity.InternalWallets.Domain.Models;
using Service.Liquidity.InternalWallets.Services;

namespace Service.Liquidity.InternalWallets.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            var myNoSqlClient = builder.CreateNoSqlClient(Program.ReloadedSettings(e => e.MyNoSqlReaderHostPort));
            
            builder
                .RegisterType<LpWalletManager>()
                .As<ILpWalletManager>()
                .As<IStartable>()
                .AutoActivate()
                .SingleInstance();
            
            builder.RegisterMyNoSqlWriter<LpWalletNoSql>(Program.ReloadedSettings(e => e.MyNoSqlWriterUrl), LpWalletNoSql.TableName);
            
            builder.RegisterBalancesClients(Program.Settings.BalancesGrpcServiceUrl, myNoSqlClient);
        }
    }
}