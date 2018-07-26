using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServiceAssetTracker.Data.Migrations
{
    public partial class FKconstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reseller_Service_CategoryId",
                table: "Reseller_Service",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reseller_Service_ResellerId",
                table: "Reseller_Service",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ResellerId",
                table: "Product",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Reference_CustomerId",
                table: "Job_Reference",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ResellerId",
                table: "Customer",
                column: "ResellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Reseller_ResellerId",
                table: "Customer",
                column: "ResellerId",
                principalTable: "Reseller",
                principalColumn: "ResellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Reference_Customer_CustomerId",
                table: "Job_Reference",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Reseller_ResellerId",
                table: "Product",
                column: "ResellerId",
                principalTable: "Reseller",
                principalColumn: "ResellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reseller_Service_Categories_CategoryId",
                table: "Reseller_Service",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reseller_Service_Reseller_ResellerId",
                table: "Reseller_Service",
                column: "ResellerId",
                principalTable: "Reseller",
                principalColumn: "ResellerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Reseller_ResellerId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Reference_Customer_CustomerId",
                table: "Job_Reference");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Reseller_ResellerId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Reseller_Service_Categories_CategoryId",
                table: "Reseller_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Reseller_Service_Reseller_ResellerId",
                table: "Reseller_Service");

            migrationBuilder.DropIndex(
                name: "IX_Reseller_Service_CategoryId",
                table: "Reseller_Service");

            migrationBuilder.DropIndex(
                name: "IX_Reseller_Service_ResellerId",
                table: "Reseller_Service");

            migrationBuilder.DropIndex(
                name: "IX_Product_ResellerId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Job_Reference_CustomerId",
                table: "Job_Reference");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ResellerId",
                table: "Customer");
        }
    }
}
