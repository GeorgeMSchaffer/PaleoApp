using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "paleo");

            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "intervals",
                schema: "paleo",
                columns: table => new
                {
                    interval_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    interval_name = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    b_age = table.Column<double>(type: "double", nullable: true),
                    t_age = table.Column<double>(type: "double", nullable: true),
                    color = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    record_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    reference_no = table.Column<int>(type: "int", nullable: true),
                    scale_no = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intervals", x => x.interval_no);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "occurrences",
                schema: "paleo",
                columns: table => new
                {
                    occurrence_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    collection_no = table.Column<int>(type: "int", nullable: true),
                    record_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    identified_name = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    identified_rank = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    identified_no = table.Column<int>(type: "int", nullable: true),
                    accepted_name = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    accepted_rank = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    accepted_no = table.Column<int>(type: "int", nullable: true),
                    early_interval = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    late_interval = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    t_age = table.Column<double>(type: "double", nullable: true),
                    b_age = table.Column<double>(type: "double", nullable: true),
                    reference_no = table.Column<int>(type: "int", nullable: true),
                    cc = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    latlng_basis = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    latlng_precision = table.Column<double>(type: "double", maxLength: 512, nullable: true),
                    geogscale = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    phylum = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    @class = table.Column<string>(name: "class", type: "varchar(512)", maxLength: 512, nullable: true),
                    order = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    family = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    genus = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_occurrences", x => x.occurrence_no);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "taxa",
                columns: table => new
                {
                    taxon_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    record_type = table.Column<string>(type: "longtext", nullable: true),
                    taxon_rank = table.Column<string>(type: "longtext", nullable: true),
                    taxon_name = table.Column<string>(type: "longtext", nullable: true),
                    taxon_attr = table.Column<string>(type: "longtext", nullable: true),
                    AcceptedNo = table.Column<int>(type: "int", nullable: true),
                    OccurrenceNo = table.Column<int>(type: "int", nullable: true),
                    accepted_rank = table.Column<string>(type: "longtext", nullable: true),
                    accepted_name = table.Column<string>(type: "longtext", nullable: true),
                    parent_no = table.Column<int>(type: "int", nullable: true),
                    reference_no = table.Column<int>(type: "int", nullable: true),
                    is_extant = table.Column<string>(type: "longtext", nullable: true),
                    n_occs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxa", x => x.taxon_no);
                    table.ForeignKey(
                        name: "FK_taxa_occurrences_OccurrenceNo",
                        column: x => x.OccurrenceNo,
                        principalSchema: "paleo",
                        principalTable: "occurrences",
                        principalColumn: "occurrence_no");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    specimen_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    record_type = table.Column<string>(type: "text", nullable: false),
                    flags = table.Column<string>(type: "text", nullable: false),
                    occurrence_no = table.Column<string>(type: "text", nullable: false),
                    reid_no = table.Column<int>(type: "int", nullable: true),
                    taxaTaxonNo = table.Column<int>(type: "int", nullable: false),
                    collection_no = table.Column<string>(type: "text", nullable: false),
                    specimen_id = table.Column<string>(type: "text", nullable: false),
                    is_type = table.Column<string>(type: "text", nullable: false),
                    specelt_no = table.Column<string>(type: "text", nullable: false),
                    specimen_side = table.Column<string>(type: "text", nullable: false),
                    specimen_part = table.Column<string>(type: "text", nullable: false),
                    specimen_sex = table.Column<string>(type: "text", nullable: false),
                    n_measured = table.Column<int>(type: "int", nullable: true),
                    measurement_source = table.Column<string>(type: "text", nullable: false),
                    magnification = table.Column<string>(type: "text", nullable: false),
                    comments = table.Column<string>(type: "text", nullable: false),
                    identified_name = table.Column<string>(type: "text", nullable: false),
                    identified_rank = table.Column<string>(type: "text", nullable: false),
                    identified_no = table.Column<int>(type: "int", nullable: true),
                    difference = table.Column<string>(type: "text", nullable: false),
                    accepted_name = table.Column<string>(type: "text", nullable: false),
                    accepted_rank = table.Column<string>(type: "text", nullable: false),
                    accepted_no = table.Column<int>(type: "int", nullable: true),
                    max_ma = table.Column<string>(type: "text", nullable: false),
                    min_ma = table.Column<string>(type: "text", nullable: false),
                    reference_no = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_species", x => x.specimen_no);
                    table.ForeignKey(
                        name: "FK_species_occurrences_accepted_no",
                        column: x => x.accepted_no,
                        principalSchema: "paleo",
                        principalTable: "occurrences",
                        principalColumn: "occurrence_no");
                    table.ForeignKey(
                        name: "FK_species_taxa_taxaTaxonNo",
                        column: x => x.taxaTaxonNo,
                        principalTable: "taxa",
                        principalColumn: "taxon_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_species_accepted_no",
                table: "species",
                column: "accepted_no");

            migrationBuilder.CreateIndex(
                name: "IX_species_taxaTaxonNo",
                table: "species",
                column: "taxaTaxonNo");

            migrationBuilder.CreateIndex(
                name: "IX_taxa_OccurrenceNo",
                table: "taxa",
                column: "OccurrenceNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "intervals",
                schema: "paleo");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropTable(
                name: "taxa");

            migrationBuilder.DropTable(
                name: "occurrences",
                schema: "paleo");
        }
    }
}
