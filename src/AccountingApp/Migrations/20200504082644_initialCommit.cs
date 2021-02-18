using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingApp.Migrations
{
    public partial class initialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Ic = table.Column<int>(nullable: false),
                    Dic = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AddressID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Company_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdminUserEdit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PersonalIdentificationNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: false),
                    CardNumber = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    AddressID = table.Column<int>(nullable: true),
                    NewPassword = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUserEdit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminUserEdit_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdminUserEdit_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PersonalIdentificationNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: false),
                    CardNumber = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    AddressID = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUser_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SuppliercompanyID = table.Column<int>(nullable: true),
                    BillToCompanyID = table.Column<int>(nullable: true),
                    PublishDate = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<string>(nullable: true),
                    TaxableSupplyDate = table.Column<string>(nullable: true),
                    IsStorno = table.Column<bool>(nullable: false),
                    PersonalIdentificationNumber = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_BillToCompanyID",
                        column: x => x.BillToCompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_SuppliercompanyID",
                        column: x => x.SuppliercompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    InvoiceID = table.Column<int>(nullable: true),
                    PriceDph = table.Column<float>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    PriceVat = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserEdit_AddressID",
                table: "AdminUserEdit",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserEdit_RoleID",
                table: "AdminUserEdit",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_AddressID",
                table: "AppUser",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_RoleID",
                table: "AppUser",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_AddressID",
                table: "Company",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_BillToCompanyID",
                table: "Invoice",
                column: "BillToCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SuppliercompanyID",
                table: "Invoice",
                column: "SuppliercompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceID",
                table: "InvoiceItem",
                column: "InvoiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUserEdit");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
