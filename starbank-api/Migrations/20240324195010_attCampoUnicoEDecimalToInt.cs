using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace starbank_api.Migrations
{
    /// <inheritdoc />
    public partial class attCampoUnicoEDecimalToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalEntities_Customers_CustomerId",
                table: "LegalEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_NaturalPersons_Customers_CustomerId",
                table: "NaturalPersons");

            migrationBuilder.DropIndex(
                name: "IX_NaturalPersons_CustomerId",
                table: "NaturalPersons");

            migrationBuilder.DropIndex(
                name: "IX_LegalEntities_CustomerId",
                table: "LegalEntities");

            migrationBuilder.DropIndex(
                name: "IX_Cards_AccountId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Transations");

            migrationBuilder.DropColumn(
                name: "MonthlyIncome",
                table: "NaturalPersons");

            migrationBuilder.DropColumn(
                name: "AnnualBilling",
                table: "LegalEntities");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "ValueInCents",
                table: "Transations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonthlyIncomeInCents",
                table: "NaturalPersons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnnualBillingInCents",
                table: "LegalEntities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BalanceInCents",
                table: "Accounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersons_Cpf",
                table: "NaturalPersons",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntities_Cnpj",
                table: "LegalEntities",
                column: "Cnpj",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NaturalPersons_Cpf",
                table: "NaturalPersons");

            migrationBuilder.DropIndex(
                name: "IX_LegalEntities_Cnpj",
                table: "LegalEntities");

            migrationBuilder.DropColumn(
                name: "ValueInCents",
                table: "Transations");

            migrationBuilder.DropColumn(
                name: "MonthlyIncomeInCents",
                table: "NaturalPersons");

            migrationBuilder.DropColumn(
                name: "AnnualBillingInCents",
                table: "LegalEntities");

            migrationBuilder.DropColumn(
                name: "BalanceInCents",
                table: "Accounts");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Transations",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyIncome",
                table: "NaturalPersons",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AnnualBilling",
                table: "LegalEntities",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Accounts",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersons_CustomerId",
                table: "NaturalPersons",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntities_CustomerId",
                table: "LegalEntities",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AccountId",
                table: "Cards",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LegalEntities_Customers_CustomerId",
                table: "LegalEntities",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NaturalPersons_Customers_CustomerId",
                table: "NaturalPersons",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
