namespace Infrastructure.Migrations;

public static class InitialMigration
{
    internal static string GetUpSql()
    {
        return """
    create type transaction_type as enum
    (
        'Deposit',
        'Withdraw'
    );

    create table accounts
    (
        account_id bigint primary key generated always as identity ,
        account_pin bigint not null,
        account_balance money not null
    );

    create table transactions
    (
        transaction_id bigint primary key generated always as identity,
        amount money not null,
        transaction_type transaction_type not null,
        account_id bigint not null references accounts

    );

    create table admin_password
    (
        admin_password text primary key
    );
    insert into admin_password (admin_password) values ('pass');
    """;
    }

    internal static string GetDownSql()
    {
        return """
        drop table accounts;
        drop table transactions;
        drop table admin_password;
        drop type transaction_type;
        """;
    }
}