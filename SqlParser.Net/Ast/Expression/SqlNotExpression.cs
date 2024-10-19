﻿using SqlParser.Net.Ast.Visitor;

namespace SqlParser.Net.Ast.Expression;

public class SqlNotExpression : SqlExpression
{
    public override void Accept(IAstVisitor visitor)
    {
        visitor.VisitSqlNotExpression(this);
    }

    public SqlNotExpression()
    {
        this.Type = SqlExpressionType.Not;
    }

    public SqlExpression Body { get; set; }

    protected bool Equals(SqlNotExpression other)
    {
        return Body.Equals(other.Body);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SqlNotExpression)obj);
    }

    public override int GetHashCode()
    {
        return Body.GetHashCode();
    }
}