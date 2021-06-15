namespace Pets.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SQLite;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Providers;

    public static class Sqls
    {
        public const string GetFood = @"
                SELECT
                    f.Id,
                    f.Name,
                    f.AnimalType,
                    f.Count
                FROM Food f
                WHERE f.Id = @Id";

        public const string CountFood = @"
                SELECT
                    COUNT(1)
                FROM Food f
                WHERE f.Name = @Name AND f.AnimalType = @AnimalType";

        public const string InsertFood = @"
                INSERT INTO Food
                (
                    Name,
                    AnimalType,
                    Count    
                )
                VALUES
                (
                    @Name,
                    @AnimalType,
                    @Count
                ); SELECT last_insert_rowid();";

        public const string UpdateCount = @"
                UPDATE Food
                SET
                    Count = Count + @Count
                WHERE
                    Food.Id = @Id";
    }
}