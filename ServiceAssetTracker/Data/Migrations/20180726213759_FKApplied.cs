using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServiceAssetTracker.Data.Migrations
{
    public partial class FKApplied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Order_ProductId",
                table: "Purchase_Order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Service_CategoryId",
                table: "Job_Service",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Service_JobReferenceId",
                table: "Job_Service",
                column: "JobReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Service_Categories_CategoryId",
                table: "Job_Service",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Service_Job_Reference_JobReferenceId",
                table: "Job_Service",
                column: "JobReferenceId",
                principalTable: "Job_Reference",
                principalColumn: "JobReferenceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Order_Product_ProductId",
                table: "Purchase_Order",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Service_Categories_CategoryId",
                table: "Job_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Service_Job_Reference_JobReferenceId",
                table: "Job_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Order_Product_ProductId",
                table: "Purchase_Order");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_Order_ProductId",
                table: "Purchase_Order");

            migrationBuilder.DropIndex(
                name: "IX_Job_Service_CategoryId",
                table: "Job_Service");

            migrationBuilder.DropIndex(
                name: "IX_Job_Service_JobReferenceId",
                table: "Job_Service");
        }
    }
}
