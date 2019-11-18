﻿using RepoDb.MySql.IntegrationTests.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace RepoDb.MySql.IntegrationTests.Setup
{
    public static class Database
    {
        #region Properties

        /// <summary>
        /// Gets or sets the connection string to be used.
        /// </summary>
        public static string ConnectionString { get; private set; } = @"Database=repodb;Data Source=localhost;User Id=user;Password=Password123;";

        #endregion

        #region Methods

        public static void Initialize()
        {
            // Check the connection string
            var environment = Environment.GetEnvironmentVariable("REPODB_ENVIRONMENT", EnvironmentVariableTarget.User);

            // Master connection
            if (environment != "DEVELOPMENT")
            {
                ConnectionString = @"Data Source=C:\MySql\Databases\RepoDb.db;Version=3;";
            }

            // Initialize MySql
            Bootstrap.Initialize();

            // Create tables
            CreateTables();
        }

        public static void Cleanup()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.DeleteAll<CompleteTable>();
                connection.DeleteAll<NonIdentityCompleteTable>();
            }
        }

        #endregion

        #region CompleteTable

        public static IEnumerable<CompleteTable> CreateCompleteTables(int count)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var tables = Helper.CreateCompleteTables(count);
                connection.InsertAll(tables);
                return tables;
            }
        }

        #endregion

        #region NonIdentityCompleteTable

        public static IEnumerable<NonIdentityCompleteTable> CreateNonIdentityCompleteTables(int count)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var tables = Helper.CreateNonIdentityCompleteTables(count);
                connection.InsertAll(tables);
                return tables;
            }
        }

        #endregion

        #region CreateTables

        private static void CreateTables()
        {
            CreateCompleteTable();
            CreateNonIdentityCompleteTable();
        }

        private static void CreateCompleteTable()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS `completetable`
                    (
                        `Id` bigint(20) NOT NULL AUTO_INCREMENT,
                        `ColumnVarchar` varchar(256) DEFAULT NULL,
                        `ColumnInt` int(11) DEFAULT NULL,
                        `ColumnDecimal2` decimal(18,2) DEFAULT NULL,
                        `ColumnDateTime` datetime DEFAULT NULL,
                        `ColumnBlob` blob,
                        `ColumnBlobAsArray` blob,
                        `ColumnBinary` binary(255) DEFAULT NULL,
                        `ColumnLongBlob` longblob,
                        `ColumnMediumBlob` mediumblob,
                        `ColumnTinyBlob` tinyblob,
                        `ColumnVarBinary` varbinary(256) DEFAULT NULL,
                        `ColumnDate` date DEFAULT NULL,
                        `ColumnDateTime2` datetime(5) DEFAULT NULL,
                        `ColumnTime` time DEFAULT NULL,
                        `ColumnTimeStamp` timestamp(5) NULL DEFAULT NULL,
                        `ColumnYear` year(4) DEFAULT NULL,
                        `ColumnGeometry` geometry DEFAULT NULL,
                        `ColumnLineString` linestring DEFAULT NULL,
                        `ColumnMultiLineString` multilinestring DEFAULT NULL,
                        `ColumnMultiPoint` multipoint DEFAULT NULL,
                        `ColumnMultiPolygon` multipolygon DEFAULT NULL,
                        `ColumnPoint` point DEFAULT NULL,
                        `ColumnPolygon` polygon DEFAULT NULL,
                        `ColumnBigint` bigint(64) DEFAULT NULL,
                        `ColumnDecimal` decimal(10,0) DEFAULT NULL,
                        `ColumnDouble` double DEFAULT NULL,
                        `ColumnFloat` float DEFAULT NULL,
                        `ColumnInt2` int(32) DEFAULT NULL,
                        `ColumnMediumInt` mediumint(16) DEFAULT NULL,
                        `ColumnReal` double DEFAULT NULL,
                        `ColumnSmallInt` smallint(8) DEFAULT NULL,
                        `ColumnTinyInt` tinyint(4) DEFAULT NULL,
                        `ColumnChar` char(1) DEFAULT NULL,
                        `ColumnJson` json DEFAULT NULL,
                        `ColumnNChar` char(16) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
                        `ColumnNVarChar` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
                        `ColumnLongText` longtext,
                        `ColumnMediumText` mediumtext,
                        `ColumText` text,
                        `ColumnTinyText` tinytext,
                        `ColumnBit` bit(1) DEFAULT NULL,
                        PRIMARY KEY (`Id`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;");
            }
        }

        private static void CreateNonIdentityCompleteTable()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS `nonidentitycompletetable`
                    (
                        `Id` bigint(20) NOT NULL,
                        `ColumnVarchar` varchar(256) DEFAULT NULL,
                        `ColumnInt` int(11) DEFAULT NULL,
                        `ColumnDecimal2` decimal(18, 2) DEFAULT NULL,
                        `ColumnDateTime` datetime DEFAULT NULL,
                        `ColumnBlob` blob,
                        `ColumnBlobAsArray` blob,
                        `ColumnBinary` binary(255) DEFAULT NULL,
                        `ColumnLongBlob` longblob,
                        `ColumnMediumBlob` mediumblob,
                        `ColumnTinyBlob` tinyblob,
                        `ColumnVarBinary` varbinary(256) DEFAULT NULL,
                        `ColumnDate` date DEFAULT NULL,
                        `ColumnDateTime2` datetime(5) DEFAULT NULL,
                        `ColumnTime` time DEFAULT NULL,
                        `ColumnTimeStamp` timestamp(5) NULL DEFAULT NULL,
                        `ColumnYear` year(4) DEFAULT NULL,
                        `ColumnGeometry` geometry DEFAULT NULL,
                        `ColumnLineString` linestring DEFAULT NULL,
                        `ColumnMultiLineString` multilinestring DEFAULT NULL,
                        `ColumnMultiPoint` multipoint DEFAULT NULL,
                        `ColumnMultiPolygon` multipolygon DEFAULT NULL,
                        `ColumnPoint` point DEFAULT NULL,
                        `ColumnPolygon` polygon DEFAULT NULL,
                        `ColumnBigint` bigint(64) DEFAULT NULL,
                        `ColumnDecimal` decimal(10, 0) DEFAULT NULL,
                        `ColumnDouble` double DEFAULT NULL,
                        `ColumnFloat` float DEFAULT NULL,
                        `ColumnInt2` int(32) DEFAULT NULL,
                        `ColumnMediumInt` mediumint(16) DEFAULT NULL,
                        `ColumnReal` double DEFAULT NULL,
                        `ColumnSmallInt` smallint(8) DEFAULT NULL,
                        `ColumnTinyInt` tinyint(4) DEFAULT NULL,
                        `ColumnChar` char(1) DEFAULT NULL,
                        `ColumnJson` json DEFAULT NULL,
                        `ColumnNChar` char(16) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
                        `ColumnNVarChar` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
                        `ColumnLongText` longtext,
                        `ColumnMediumText` mediumtext,
                        `ColumText` text,
                        `ColumnTinyText` tinytext,
                        `ColumnBit` bit(1) DEFAULT NULL,
                        PRIMARY KEY(`Id`)
                    ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;");
            }
        }

        #endregion
    }
}