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
        #region food
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
        #endregion

        #region breed
        public const string GetBreed = @"
                SELECT
                    b.Id,
                    b.Name,
                    b.AnimalType
                FROM Breed b
                WHERE b.Id = @Id";

        public const string CountBreed = @"
                SELECT
                    COUNT(1)
                FROM Breed b
                WHERE b.Name = @Name AND b.AnimalType = @AnimalType";

        public const string InsertBreed = @"
                INSERT INTO Breed
                (
                    Name,
                    AnimalType    
                )
                VALUES
                (
                    @Name,
                    @AnimalType
                ); SELECT last_insert_rowid();";

        #endregion

        #region animal
        public const string GetAnimal = @"
                SELECT
                    a.Id AId,
                    a.Type AType,
                    a.Name AName,
                    b.Id BId,
                    b.AnimalType BAnimalType,
                    b.Name BName,
                    c.Weight CWeight,
                    d.TailLength DTailLength,
                    f2.Id F2Id,
                    f2.AnimalType F2AnimalType,
                    f2.Name F2Name,
                    f2.Count F2Count,
                    f1.Id F1Id,
                    f1.DateTimeUtc F1DateTimeUtc,
                    f1.Count F1Count
                FROM Animal a
                JOIN Breed b ON b.Id = a.BreedId
                LEFT JOIN Cat c ON c.AnimalId = a.Id
                LEFT JOIN Dog d ON d.AnimalId = a.Id
                LEFT JOIN Feeding f1 ON f1.AnimalId = a.Id
                LEFT JOIN Food f2 ON f1.FoodId = f2.Id
                WHERE a.Id = @Id
                ORDER BY f1.DateTimeUtc DESC";

        public const string CountAnimal = @"
                SELECT
                    COUNT(1)
                FROM Animal a
                WHERE a.Name = @Name;";
        public const string CountBreedAnimalType = @"
                SELECT
                    COUNT(1)
                FROM Breed b
                WHERE b.Id = @BreedId AND b.AnimalType = @Type";

        public const string InsertAnimal = @"
                INSERT INTO Animal
                (
                    Type,
                    Name,
                    BreedId
                )
                VALUES 
                (
                    @Type,
                    @Name,
                    @BreedId
                ); SELECT last_insert_rowid()";

        public const string InsertCat = @"
                            INSERT INTO Cat
                            (
                                AnimalId,
                                Weight
                            )
                            VALUES
                            (
                                @AnimalId,
                                @Weight
                            )";

        public const string InsertDog = @"
                            INSERT INTO Dog
                            (
                                AnimalId,
                                TailLength
                            )
                            VALUES
                            (
                                @AnimalId,
                                @TailLength
                            )";

        public const string CountFoodAnimalTypeCount = @"
                SELECT
                    COUNT(1)
                FROM Food f WHERE f.Id = @FoodId AND f.AnimalType = @AnimalType AND f.Count >= @Count";

        public const string InsertFeeding = @"
                INSERT INTO Feeding
                (
                    AnimalId,
                    FoodId,
                    DateTimeUtc,
                    Count
                )
                VALUES
                (
                    @AnimalId,
                    @FoodId,
                    @DateTimeUtc,
                    @Count
                );";

        #endregion
    }
}