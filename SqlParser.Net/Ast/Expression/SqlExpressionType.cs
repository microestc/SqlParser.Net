﻿namespace SqlParser.Net.Ast.Expression;

public enum SqlExpressionType
{
    Select,
    SelectItem,
    SelectQuery,
    Table,
    Where,
    Condition,
    Property,
    Identifier,
    AllColumn,
    Constant,
    JoinTable,
    OrderBy,
    OrderByItem,
    Binary,
    Number,
    String,
    FunctionCall,
    Null,
    GroupBy,
    BetweenAnd,
    Update,
    Insert,
    Delete,
    Variable,
    Exists,
    WithSubQuery,
    UnionQuery,
    All,
    Any,
    In,
    Case,
    CaseItem,
    Limit,
    Over,
    PartitionBy,
    Not
}