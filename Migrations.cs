using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace HYT.NewsDemo
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("NewsRecord", table => table
              .ContentPartRecord()
              .Column<string>("NewsTitle", c => c.WithLength(200))
              .Column<string>("NewsContent", c => c.WithLength(50))
              .Column<string>("NewsCategory"));

            ContentDefinitionManager.AlterPartDefinition("NewsPart", part => part
              .Attachable(false)
             );

            ContentDefinitionManager.AlterTypeDefinition("News", type => type
                .WithPart("NewsPart")
            );

            return 1;
        }


    }
}