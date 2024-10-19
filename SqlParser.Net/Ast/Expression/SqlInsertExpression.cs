﻿using SqlParser.Net.Ast.Visitor;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SqlParser.Net.Ast.Expression;

public class SqlInsertExpression : SqlExpression
{
    public override void Accept(IAstVisitor visitor)
    {
        visitor.VisitSqlInsertExpression(this);
    }
    public SqlInsertExpression()
    {
        this.Type = SqlExpressionType.Insert;
    }

    public SqlExpression Table { get; set; }

    public List<SqlExpression> Columns { get; set; }

    /// <summary>
    /// Since MySQL, SQL Server, SQLite, and PostgreSQL support inserting multiple rows of data in an insert statement, the values ​​value is a list.
    /// 由于mysql，sqlserver,SQLite,PostgreSQL支持在insert语句中插入多行数据，所以values值是列表
    /// </summary>
    public List<List<SqlExpression>> ValuesList { get; set; }

    /// <summary>
    /// INSERT INTO TEST2(name) SELECT name AS name2 FROM TEST t
    /// </summary>
    public SqlSelectExpression FromSelect { get; set; }

    public List<string> Comments { get; set; }

    protected bool Equals(SqlInsertExpression other)
    {
        if (Columns is null ^ other.Columns is null)
        {
            return false;
        }
        else if (Columns != null && other.Columns != null)
        {
            if (Columns.Count != other.Columns.Count)
            {
                return false;
            }

            for (var i = 0; i < Columns.Count; i++)
            {
                var item = Columns[i];
                var item2 = other.Columns[i];
                if (!item.Equals(item2))
                {
                    return false;
                }
            }
        }
        if (ValuesList is null ^ other.ValuesList is null)
        {
            return false;
        }
        else if (ValuesList != null && other.ValuesList != null)
        {
            if (ValuesList.Count != other.ValuesList.Count)
            {
                return false;
            }

            for (var i = 0; i < ValuesList.Count; i++)
            {
                var items1 = ValuesList[i];
                var items2 = other.ValuesList[i];
                if (items1 == null ^ items2 == null)
                {
                    return false;
                }

                if (items1 != null && items2 != null)
                {
                    for (int j = 0; j < items1.Count; j++)
                    {
                        var item = items1[i];
                        var item2 = items2[i];
                        if (!item.Equals(item2))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        if (!Table.Equals(other.Table))
        {
            return false;
        }

        if (FromSelect == null ^ other.FromSelect == null)
        {
            return false;
        }
        else if (FromSelect != null && other.FromSelect != null)
        {
            return FromSelect.Equals(other.FromSelect);
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SqlInsertExpression)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Table.GetHashCode();
            hashCode = (hashCode * 397) ^ Columns.GetHashCode();
            hashCode = (hashCode * 397) ^ ValuesList.GetHashCode();
            hashCode = (hashCode * 397) ^ FromSelect.GetHashCode();
            return hashCode;
        }
    }
}