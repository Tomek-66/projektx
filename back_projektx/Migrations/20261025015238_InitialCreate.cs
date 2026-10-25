using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace back_projektx.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceWojewodztwo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceWojewodztwo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlacePowiat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdWojewodztwo = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacePowiat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacePowiat_PlaceWojewodztwo_IdWojewodztwo",
                        column: x => x.IdWojewodztwo,
                        principalTable: "PlaceWojewodztwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IdTransactionType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop_TransactionType_IdTransactionType",
                        column: x => x.IdTransactionType,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    IdType = table.Column<int>(type: "integer", nullable: false),
                    Nick = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ValidCode = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    Img64 = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<int>(type: "integer", nullable: true),
                    BirthdateTicks = table.Column<long>(type: "bigint", nullable: true),
                    LoginDateTicks = table.Column<long>(type: "bigint", nullable: true),
                    Note = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Prestige = table.Column<int>(type: "integer", nullable: false),
                    Money = table.Column<float>(type: "real", nullable: false),
                    LevelCount = table.Column<int>(type: "integer", nullable: false),
                    ImageCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_User_UserType_IdType",
                        column: x => x.IdType,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaceGmina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdWojewodztwo = table.Column<int>(type: "integer", nullable: false),
                    IdPowiat = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceGmina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceGmina_PlacePowiat_IdPowiat",
                        column: x => x.IdPowiat,
                        principalTable: "PlacePowiat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaceGmina_PlaceWojewodztwo_IdWojewodztwo",
                        column: x => x.IdWojewodztwo,
                        principalTable: "PlaceWojewodztwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    IdRoom = table.Column<int>(type: "integer", nullable: false),
                    GuidUser = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    DateTimeTicks = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ChatMessage_ChatRoom_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "ChatRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessage_User_GuidUser",
                        column: x => x.GuidUser,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoomUser",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    IdRoom = table.Column<int>(type: "integer", nullable: false),
                    GuidUser = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    ActiveTicks = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomUser", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ChatRoomUser_ChatRoom_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "ChatRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatRoomUser_User_GuidUser",
                        column: x => x.GuidUser,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IdType = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    DatetimeTicks = table.Column<long>(type: "bigint", nullable: false),
                    GuidUserSend = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    GuidUserReceiver = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_IdType",
                        column: x => x.IdType,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_User_GuidUserReceiver",
                        column: x => x.GuidUserReceiver,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_User_GuidUserSend",
                        column: x => x.GuidUserSend,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    GuidUser = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    GuidUserFor = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_UserAccess_User_GuidUser",
                        column: x => x.GuidUser,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAccess_User_GuidUserFor",
                        column: x => x.GuidUserFor,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserImage",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    GuidUser = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Img64 = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImage", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_UserImage_User_GuidUser",
                        column: x => x.GuidUser,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMessage",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    GuidUserSend = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    GuidUserReceive = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Message = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DatetimeTicks = table.Column<long>(type: "bigint", nullable: false),
                    Img64 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessage", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_UserMessage_User_GuidUserReceive",
                        column: x => x.GuidUserReceive,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMessage_User_GuidUserSend",
                        column: x => x.GuidUserSend,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaceSearch",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    GuidUser = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    IdPlaceGmina = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceSearch", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PlaceSearch_PlaceGmina_IdPlaceGmina",
                        column: x => x.IdPlaceGmina,
                        principalTable: "PlaceGmina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaceSearch_User_GuidUser",
                        column: x => x.GuidUser,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaceUser",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    GuidUser = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    IdPlaceGmina = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceUser", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PlaceUser_PlaceGmina_IdPlaceGmina",
                        column: x => x.IdPlaceGmina,
                        principalTable: "PlaceGmina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaceUser_User_GuidUser",
                        column: x => x.GuidUser,
                        principalTable: "User",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_GuidUser",
                table: "ChatMessage",
                column: "GuidUser");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_IdRoom",
                table: "ChatMessage",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomUser_GuidUser",
                table: "ChatRoomUser",
                column: "GuidUser");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomUser_IdRoom",
                table: "ChatRoomUser",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceGmina_IdPowiat",
                table: "PlaceGmina",
                column: "IdPowiat");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceGmina_IdWojewodztwo",
                table: "PlaceGmina",
                column: "IdWojewodztwo");

            migrationBuilder.CreateIndex(
                name: "IX_PlacePowiat_IdWojewodztwo",
                table: "PlacePowiat",
                column: "IdWojewodztwo");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceSearch_GuidUser",
                table: "PlaceSearch",
                column: "GuidUser");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceSearch_IdPlaceGmina",
                table: "PlaceSearch",
                column: "IdPlaceGmina");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceUser_GuidUser",
                table: "PlaceUser",
                column: "GuidUser");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceUser_IdPlaceGmina",
                table: "PlaceUser",
                column: "IdPlaceGmina");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_IdTransactionType",
                table: "Shop",
                column: "IdTransactionType");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_GuidUserReceiver",
                table: "Transaction",
                column: "GuidUserReceiver");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_GuidUserSend",
                table: "Transaction",
                column: "GuidUserSend");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IdType",
                table: "Transaction",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdType",
                table: "User",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_User_Nick",
                table: "User",
                column: "Nick",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Phone",
                table: "User",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_GuidUser",
                table: "UserAccess",
                column: "GuidUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_GuidUserFor",
                table: "UserAccess",
                column: "GuidUserFor");

            migrationBuilder.CreateIndex(
                name: "IX_UserImage_GuidUser",
                table: "UserImage",
                column: "GuidUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessage_GuidUserReceive",
                table: "UserMessage",
                column: "GuidUserReceive");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessage_GuidUserSend",
                table: "UserMessage",
                column: "GuidUserSend");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "ChatRoomUser");

            migrationBuilder.DropTable(
                name: "PlaceSearch");

            migrationBuilder.DropTable(
                name: "PlaceUser");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "UserAccess");

            migrationBuilder.DropTable(
                name: "UserImage");

            migrationBuilder.DropTable(
                name: "UserMessage");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "PlaceGmina");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PlacePowiat");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "PlaceWojewodztwo");
        }
    }
}
