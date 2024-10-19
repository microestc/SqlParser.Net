﻿using SqlParser.Net.Ast.Expression;

namespace SqlParser.Net.Ast.Visitor;

public interface IAstVisitor
{
    void VisitSqlAllColumnExpression(SqlAllColumnExpression sqlAllColumnExpression);
    void VisitSqlAllExpression(SqlAllExpression sqlAllExpression);
    void VisitSqlAnyExpression(SqlAnyExpression sqlAnyExpression);
    void VisitSqlBetweenAndExpression(SqlBetweenAndExpression sqlBetweenAndExpression);
    void VisitSqlBinaryExpression(SqlBinaryExpression sqlBinaryExpression);
    void VisitSqlCaseExpression(SqlCaseExpression sqlCaseExpression);
    void VisitSqlCaseItemExpression(SqlCaseItemExpression sqlCaseItemExpression);
    void VisitSqlDeleteExpression(SqlDeleteExpression sqlDeleteExpression);
    void VisitSqlExistsExpression(SqlExistsExpression sqlExistsExpression);
    void VisitSqlExpression(SqlExpression sqlExpression);
    void VisitSqlFunctionCallExpression(SqlFunctionCallExpression sqlFunctionCallExpression);
    void VisitSqlGroupByExpression(SqlGroupByExpression sqlGroupByExpression);
    void VisitSqlIdentifierExpression(SqlIdentifierExpression sqlIdentifierExpression);
    void VisitSqlInExpression(SqlInExpression sqlInExpression);
    void VisitSqlInsertExpression(SqlInsertExpression sqlInsertExpression);
    void VisitSqlJoinTableExpression(SqlJoinTableExpression sqlJoinTableExpression);
    void VisitSqlLimitExpression(SqlLimitExpression sqlLimitExpression);
    void VisitSqlNotExpression(SqlNotExpression sqlNotExpression);
    void VisitSqlNullExpression(SqlNullExpression sqlNullExpression);
    void VisitSqlNumberExpression(SqlNumberExpression sqlNumberExpression);
    void VisitSqlOrderByExpression(SqlOrderByExpression sqlOrderByExpression);
    void VisitSqlOrderByItemExpression(SqlOrderByItemExpression sqlOrderByItemExpression);
    void VisitSqlOverExpression(SqlOverExpression sqlOverExpression);
    void VisitSqlPartitionByExpression(SqlPartitionByExpression sqlPartitionByExpression);
    void VisitSqlPivotTableExpression(SqlPivotTableExpression sqlPivotTableExpression);
    void VisitSqlPropertyExpression(SqlPropertyExpression sqlPropertyExpression);
    void VisitSqlReferenceTableExpression(SqlReferenceTableExpression sqlReferenceTableExpression);
    void VisitSqlSelectExpression(SqlSelectExpression sqlSelectExpression);
    void VisitSqlSelectItemExpression(SqlSelectItemExpression sqlSelectItemExpression);
    void VisitSqlSelectQueryExpression(SqlSelectQueryExpression sqlSelectQueryExpression);
    void VisitSqlStringExpression(SqlStringExpression sqlStringExpression);
    void VisitSqlTableExpression(SqlTableExpression sqlTableExpression);
    void VisitSqlUnionQueryExpression(SqlUnionQueryExpression sqlUnionQueryExpression);
    void VisitSqlUpdateExpression(SqlUpdateExpression sqlUpdateExpression);
    void VisitSqlVariableExpression(SqlVariableExpression sqlVariableExpression);
    void VisitSqlWithinGroupExpression(SqlWithinGroupExpression sqlWithinGroupExpression);
    void VisitSqlWithSubQueryExpression(SqlWithSubQueryExpression sqlWithSubQueryExpression);
}