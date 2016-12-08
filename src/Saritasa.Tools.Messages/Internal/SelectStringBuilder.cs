﻿using System.Collections.Generic;
using Saritasa.Tools.Messages.Internal.Clauses;
using Saritasa.Tools.Messages.Internal.Enums;

namespace Saritasa.Tools.Messages.Internal
{
    /// <summary>
    /// The SELECT statement abstract builder.
    /// </summary>
    /// <seealso cref="Saritasa.Tools.Messages.Internal.ISelectStringBuilder" />
    internal abstract class SelectStringBuilder : ISelectStringBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectStringBuilder"/> class.
        /// </summary>
        protected SelectStringBuilder()
        {
            SelectedColumns = new List<string>();
            SelectedTables = new List<string>();
            WhereStatement = new List<WhereClause>();
            GroupByColumns = new List<string>();
            OrderByStatement = new List<OrderByClause>();
        }

        /// <inheritdoc />
        public IList<string> SelectedColumns { get; }
        /// <inheritdoc />
        public bool IsDistinct { get; set; }
        /// <inheritdoc />
        public IList<string> SelectedTables { get; }
        /// <inheritdoc />
        public IList<WhereClause> WhereStatement { get; }
        /// <inheritdoc />
        public IList<string> GroupByColumns { get; }
        /// <inheritdoc />
        public IList<OrderByClause> OrderByStatement { get; }
        /// <inheritdoc />
        public int? SkipRows { get; set; }
        /// <inheritdoc />
        public int? TakeRows { get; set; }

        /// <inheritdoc />
        public ISelectStringBuilder SelectAll()
        {
            SelectedColumns.Clear();
            return this;
        }

        /// <inheritdoc />
        public ISelectStringBuilder Select(params string[] columnNames)
        {
            SelectedColumns.Clear();
            foreach (var columnName in columnNames)
            {
                SelectedColumns.Add(columnName);
            }
            return this;
        }

        /// <inheritdoc />
        public ISelectStringBuilder AddSelect(params string[] columnNames)
        {
            foreach (var column in columnNames)
            {
                SelectedColumns.Add(column);
            }
            return this;
        }

        /// <inheritdoc />
        public ISelectStringBuilder Distinct()
        {
            IsDistinct = true;
            return this;
        }

        /// <inheritdoc />
        public ISelectStringBuilder From(params string[] tableNames)
        {
            SelectedTables.Clear();
            foreach (var table in tableNames)
            {
                SelectedTables.Add(table);
            }
            return this;
        }

        /// <inheritdoc />
        public ISelectStringBuilder GroupBy(params string[] columnNames)
        {
            foreach (var columnName in columnNames)
            {
                GroupByColumns.Add(columnName);
            }
            return this;
        }

        /// <inheritdoc />
        public WhereClause Where(string columnName)
        {
            var clause = new WhereClause(this, columnName);
            WhereStatement.Add(clause);
            return clause;
        }

        /// <inheritdoc />
        public ISelectStringBuilder Where(string columnName, ComparisonOperator @operator, object value)
        {
            var clause = new WhereClause(this, columnName, @operator, value);
            WhereStatement.Add(clause);
            return this;
        }

        /// <inheritdoc />
        public ISelectStringBuilder OrderBy(string columnName)
        {
            var clause = new OrderByClause(columnName);
            OrderByStatement.Add(clause);
            return this;
        }

        /// <inheritdoc />
        public ISelectStringBuilder OrderBy(string columnName, SortingOperator @operator)
        {
            var clause = new OrderByClause(columnName, @operator);
            OrderByStatement.Add(clause);
            return this;
        }

        /// <inheritdoc />
        public ISelectStringBuilder Skip(int rows)
        {
            SkipRows = rows;
            return this;
        }

        /// <inheritdoc />
        public ISelectStringBuilder Take(int rows)
        {
            TakeRows = rows;
            return this;
        }

        /// <inheritdoc />
        public abstract string Build();
    }
}
