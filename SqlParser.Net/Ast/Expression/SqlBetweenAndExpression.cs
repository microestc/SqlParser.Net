﻿using SqlParser.Net.Ast.Visitor;
using SqlParser.Net.Lexer;

namespace SqlParser.Net.Ast.Expression;

public class SqlBetweenAndExpression : SqlExpression
{
    public override void Accept(IAstVisitor visitor)
    {
        visitor.VisitSqlBetweenAndExpression(this);
    }
    public SqlBetweenAndExpression()
    {
        this.Type = SqlExpressionType.BetweenAnd;
    }

    public SqlBetweenAndExpressionTokenContext TokenContext { get; set; }

    /// <summary>
    /// not in
    /// </summary>
    public bool IsNot { get; set; }

    public SqlExpression Body { get; set; }
    public SqlExpression Begin { get; set; }
    public SqlExpression End { get; set; }

    protected bool Equals(SqlBetweenAndExpression other)
    {
        if (IsNot != other.IsNot)
        {
            return false;
        }

        if (!CompareTwoSqlExpression(Body,other.Body))
        {
            return false;
        }

        if (!CompareTwoSqlExpression(Begin, other.Begin))
        {
            return false;
        }

        if (!CompareTwoSqlExpression(End, other.End))
        {
            return false;
        }
       
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SqlBetweenAndExpression)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Body.GetHashCode();
            hashCode = (hashCode * 397) ^ Begin.GetHashCode();
            hashCode = (hashCode * 397) ^ End.GetHashCode();
            return hashCode;
        }
    }
}

public class SqlBetweenAndExpressionTokenContext
{
    public Token? Between { get; set; }
    public Token? And { get; set; }
    public Token? Not { get; set; }
}

