using SqlParser.Net.Ast.Expression;
using SqlParser.Net.Ast.Visitor;
using System.Xml.Linq;

namespace SqlParser.Net.Test;

public class InsertTest
{
    [Fact]
    public void TestInsert()
    {
        var sql = "insert into test11(name,id) values('a1','a2'),('a3','a4')";
        var sqlAst = DbUtils.Parse(sql, DbType.MySql);
        var unitTestAstVisitor = new UnitTestAstVisitor();
        sqlAst.Accept(unitTestAstVisitor);
        var result = unitTestAstVisitor.GetResult();
        var expect = new SqlInsertExpression()
        {
            Columns = new List<SqlExpression>()
            {
                new SqlIdentifierExpression()
                {
                    Value = "name"
                },
                new SqlIdentifierExpression()
                {
                    Value = "id"
                },
            },
            ValuesList = new List<List<SqlExpression>>()
            {
                new List<SqlExpression>()
                {
                    new SqlStringExpression()
                    {
                        Value = "a1"
                    },
                    new SqlStringExpression()
                    {
                        Value = "a2"
                    },
                },
                new List<SqlExpression>()
                {
                    new SqlStringExpression()
                    {
                        Value = "a3"
                    },
                    new SqlStringExpression()
                    {
                        Value = "a4"
                    },
                },
            },
            Table = new SqlTableExpression()
            {
                Name = new SqlIdentifierExpression()
                {
                    Value = "test11"
                },
            },
        };


        Assert.True(sqlAst.Equals(expect));
    }

    [Fact]
    public void TestInsert2()
    {
        var sql = "insert into test11(name,id) values('a1','a2')";
        var sqlAst = DbUtils.Parse(sql, DbType.SqlServer);
        var unitTestAstVisitor = new UnitTestAstVisitor();
        sqlAst.Accept(unitTestAstVisitor);
        var result = unitTestAstVisitor.GetResult();
        var expect = new SqlInsertExpression()
        {
            Columns = new List<SqlExpression>()
            {
                new SqlIdentifierExpression()
                {
                    Value = "name"
                },
                new SqlIdentifierExpression()
                {
                    Value = "id"
                },
            },
            ValuesList = new List<List<SqlExpression>>()
            {
                new List<SqlExpression>()
                {
                    new SqlStringExpression()
                    {
                        Value = "a1"
                    },
                    new SqlStringExpression()
                    {
                        Value = "a2"
                    },
                },
            },
            Table = new SqlTableExpression()
            {
                Name = new SqlIdentifierExpression()
                {
                    Value = "test11"
                },
            },
        };

        Assert.True(sqlAst.Equals(expect));
    }
    [Fact]
    public void TestInsert3()
    {
        var sql = "insert into test11(name,id) values(@a,@b)";
        var sqlAst = DbUtils.Parse(sql, DbType.SqlServer);
        var unitTestAstVisitor = new UnitTestAstVisitor();
        sqlAst.Accept(unitTestAstVisitor);
        var result = unitTestAstVisitor.GetResult();
        var expect = new SqlInsertExpression()
        {
            Columns = new List<SqlExpression>()
            {
                new SqlIdentifierExpression()
                {
                    Value = "name"
                },
                new SqlIdentifierExpression()
                {
                    Value = "id"
                },
            },
            ValuesList = new List<List<SqlExpression>>()
            {
                new List<SqlExpression>()
                {
                    new SqlVariableExpression()
                    {
                        Name = "a",
                        Prefix = "@",
                    },
                    new SqlVariableExpression()
                    {
                        Name = "b",
                        Prefix = "@",
                    },
                },
            },
            Table = new SqlTableExpression()
            {
                Name = new SqlIdentifierExpression()
                {
                    Value = "test11"
                },
            },
        };


        Assert.True(sqlAst.Equals(expect));
    }

    [Fact]
    public void TestInsert4()
    {
        var sql = "INSERT INTO TEST VALUES ('a1')";
        var sqlAst = DbUtils.Parse(sql, DbType.Oracle);
        var unitTestAstVisitor = new UnitTestAstVisitor();
        sqlAst.Accept(unitTestAstVisitor);
        var result = unitTestAstVisitor.GetResult();
        var expect = new SqlInsertExpression()
        {
            ValuesList = new List<List<SqlExpression>>()
            {
                new List<SqlExpression>()
                {
                    new SqlStringExpression()
                    {
                        Value = "a1"
                    },
                },
            },
            Table = new SqlTableExpression()
            {
                Name = new SqlIdentifierExpression()
                {
                    Value = "TEST"
                },
            },
        };


        Assert.True(sqlAst.Equals(expect));
    }

    [Fact]
    public void TestInsert5()
    {
        var sql = "INSERT INTO TEST2(name) SELECT name AS name2 FROM TEST t";
        var sqlAst = DbUtils.Parse(sql, DbType.MySql);
        var unitTestAstVisitor = new UnitTestAstVisitor();
        sqlAst.Accept(unitTestAstVisitor);
        var result = unitTestAstVisitor.GetResult();
        var expect = new SqlInsertExpression()
        {
            Columns = new List<SqlExpression>()
            {
                new SqlIdentifierExpression()
                {
                    Value = "name"
                },
            },
            Table = new SqlTableExpression()
            {
                Name = new SqlIdentifierExpression()
                {
                    Value = "TEST2"
                },
            },
            FromSelect = new SqlSelectExpression()
            {
                Query = new SqlSelectQueryExpression()
                {
                    Columns = new List<SqlSelectItemExpression>()
                    {
                        new SqlSelectItemExpression()
                        {
                            Body = new SqlIdentifierExpression()
                            {
                                Value = "name"
                            },
                            Alias = new SqlIdentifierExpression()
                            {
                                Value = "name2"
                            },
                        },
                    },
                    From = new SqlTableExpression()
                    {
                        Name = new SqlIdentifierExpression()
                        {
                            Value = "TEST"
                        },
                        Alias = new SqlIdentifierExpression()
                        {
                            Value = "t"
                        },
                    },
                },
            },
        };


        Assert.True(sqlAst.Equals(expect));
    }

    [Fact]
    public void TestInsert6()
    {
        var sql = "insert into message.dbo.TempSMS(sms) values ('333')";
        var sqlAst = DbUtils.Parse(sql, DbType.MySql);
        var unitTestAstVisitor = new UnitTestAstVisitor();
        sqlAst.Accept(unitTestAstVisitor);
        var result = unitTestAstVisitor.GetResult();
        var expect = new SqlInsertExpression()
        {
            Columns = new List<SqlExpression>()
            {
                new SqlIdentifierExpression()
                {
                    Value = "sms",
                },
            },
            ValuesList = new List<List<SqlExpression>>()
            {
                new List<SqlExpression>()
                {
                    new SqlStringExpression()
                    {
                        Value = "333"
                    },
                },
            },
            Table = new SqlTableExpression()
            {
                Name = new SqlIdentifierExpression()
                {
                    Value = "TempSMS",
                },
                Schema = new SqlIdentifierExpression()
                {
                    Value = "message.dbo",
                },
            },
        };

        Assert.True(sqlAst.Equals(expect));
    }

    [Fact]
    public void TestInsert7()
    {
        var sql = "INSERT INTO \"TEST\"  \r\n           (\"Value\",\"Age\")\r\n     VALUES\r\n           (:Value,:Age) ";
        var sqlAst = DbUtils.Parse(sql, DbType.Oracle);
        var unitTestAstVisitor = new UnitTestAstVisitor();
        sqlAst.Accept(unitTestAstVisitor);
        var result = unitTestAstVisitor.GetResult();
        var expect = new SqlInsertExpression()
        {
            Columns = new List<SqlExpression>()
            {
                new SqlIdentifierExpression()
                {
                    Value = "Value",
                    LeftQualifiers = "\"",
                    RightQualifiers = "\"",
                },
                new SqlIdentifierExpression()
                {
                    Value = "Age",
                    LeftQualifiers = "\"",
                    RightQualifiers = "\"",
                },
            },
            ValuesList = new List<List<SqlExpression>>()
            {
                new List<SqlExpression>()
                {
                    new SqlVariableExpression()
                    {
                        Name = "Value",
                        Prefix = ":",
                    },
                    new SqlVariableExpression()
                    {
                        Name = "Age",
                        Prefix = ":",
                    },
                },
            },
            Table = new SqlTableExpression()
            {
                Name = new SqlIdentifierExpression()
                {
                    Value = "TEST",
                    LeftQualifiers = "\"",
                    RightQualifiers = "\"",
                },
            },
        };


        Assert.True(sqlAst.Equals(expect));
    }

    [Fact]
    public void TestInsertCheckIfParsingIsComplete()
    {
        var sql = "insert into test11(name,id) values('a1','a2') a";
        var sqlAst = new SqlExpression();
        Assert.Throws<Exception>(() =>
        {
            var t = TimeUtils.TestMicrosecond((() => { sqlAst = DbUtils.Parse(sql, DbType.SqlServer); }));
        });
    }
}