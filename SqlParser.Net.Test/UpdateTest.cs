using SqlParser.Net.Ast.Expression;

namespace SqlParser.Net.Test;

public class UpdateTest
{
    [Fact]
    public void TestUpdate()
    {
        var sql = "update test set name ='4',d='2024-11-22 08:19:47.243' where name ='1'";
        var sqlAst = DbUtils.Parse(sql, DbType.MySql);
        var expect = new SqlUpdateExpression()
        {
            Items = new List<SqlExpression>()
            {
                new SqlBinaryExpression()
                {
                    Left = new SqlIdentifierExpression()
                    {
                        Name = "name"
                    },
                    Operator = SqlBinaryOperator.EqualTo,
                    Right = new SqlStringExpression()
                    {
                        Value = "4"
                    }
                },
                new SqlBinaryExpression()
                {
                    Left = new SqlIdentifierExpression()
                    {
                        Name = "d"
                    },
                    Operator = SqlBinaryOperator.EqualTo,
                    Right = new SqlStringExpression()
                    {
                        Value = "2024-11-22 08:19:47.243"
                    }
                }
            },
            Table = new SqlTableExpression()
            {
                Name = new SqlIdentifierExpression()
                {
                    Name = "test"
                }
            },
            Where = new SqlBinaryExpression()
            {
                Left = new SqlIdentifierExpression()
                {
                    Name = "name"
                },
                Operator = SqlBinaryOperator.EqualTo,
                Right = new SqlStringExpression()
                {
                    Value = "1"
                }
            }
        };
        Assert.True(sqlAst.Equals(expect));

    }


}