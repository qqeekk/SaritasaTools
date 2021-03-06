﻿namespace Saritasa.BoringWarehouse.Domain
{
    using System.Collections.Generic;

    public class PagedResult<T>
    {
        public PagedResult(IEnumerable<T> items, int offset, int limit, long total, long filteredCount)
        {
            Items = items; // Copy?
            Offset = offset;
            Limit = limit;
            FilteredCount = filteredCount;
            Total = total;
        }

        public IEnumerable<T> Items { get; set; }

        public int Offset { get; }

        public int Limit { get; }

        public long FilteredCount { get; }

        public long Total { get; }
    }
}
