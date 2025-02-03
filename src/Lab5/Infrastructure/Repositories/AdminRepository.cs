using Application.Abstraction.Repositories;
using Application.Models;
using Npgsql;

namespace Infrastructure.Repositories;

internal class AdminRepository : IAdminRepository
{
    private int _linterAvaider;
    public int LinterAvaider => _linterAvaider;

    public AdminPassword? GetAdminPassword
    {
        get
        {
            _linterAvaider = 0;
            using NpgsqlConnection con = GetConnection();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from admin_password";
            con.Open();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() is false)
            {
                return null;
            }

            return new AdminPassword(
                reader.GetString(0),
                reader.GetInt32(1),
                reader.GetInt32(2));
        }
    }

    public void GetUpSql()
    {
        _linterAvaider = 0;
        if (CheckIfUp())
        {
            return;
        }

        using NpgsqlConnection con = GetConnection();
        using var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        cmd.CommandText = """
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
                admin_password text primary key,
                max_characters int,
                exact_characters int
            );
            insert into admin_password (admin_password, max_characters, exact_characters) values ('pass', 0, 0);
            """;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void GetDownSql()
    {
        _linterAvaider = 0;
        using NpgsqlConnection con = GetConnection();
        using var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        cmd.CommandText = """
            drop table transactions;
            drop table accounts;
            drop table admin_password;
            drop type transaction_type;
            """;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    public bool CheckIfUp()
    {
        _linterAvaider = 0;
        using NpgsqlConnection con = GetConnection();
        using var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select exists(select from information_schema.tables where table_name = 'accounts');";
        con.Open();
        NpgsqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        return reader.GetBoolean(0);
    }

    public void ChangeAdminPasswordSettings(AdminPassword newPassword)
    {
        _linterAvaider = 0;
        using NpgsqlConnection con = GetConnection();
        using var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        cmd.CommandText
            = "UPDATE admin_password SET admin_password = @password, max_characters = @new_max, exact_characters = @new_exact;";
        cmd.Parameters.AddWithValue("@password", newPassword.Password);
        cmd.Parameters.AddWithValue("@new_max", newPassword.MaxCharacters);
        cmd.Parameters.AddWithValue("@new_exact", newPassword.ExactCharacters);
        con.Open();
        cmd.ExecuteNonQuery();
    }

    private static NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(@"Host=localhost;Port=5432;Username=postgres;Password=123;Database=postgres;");
    }
}