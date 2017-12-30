using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AnimeNetCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Checked = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UrlSeo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Body = table.Column<string>(maxLength: 5000, nullable: false),
                    Meta = table.Column<string>(maxLength: 25, nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    NetLikeCount = table.Column<int>(nullable: false),
                    PostedOn = table.Column<DateTime>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 250, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    UrlSeo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Checked = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UrlSeo = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Body = table.Column<string>(maxLength: 1000, nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    NetLikeCount = table.Column<int>(nullable: false),
                    PostId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    CategotyId = table.Column<string>(nullable: false),
                    PostId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: true),
                    Checked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => new { x.CategotyId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostLikes",
                columns: table => new
                {
                    PostId = table.Column<string>(nullable: false),
                    Dislike = table.Column<bool>(nullable: false),
                    Like = table.Column<bool>(nullable: false),
                    PostId1 = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLikes", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_PostLikes_Posts_PostId1",
                        column: x => x.PostId1,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostVideos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<string>(nullable: true),
                    VideoSiteName = table.Column<string>(nullable: true),
                    VideoThumbnail = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostVideos_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostId = table.Column<string>(nullable: false),
                    TagId = table.Column<string>(nullable: false),
                    Checked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    CommentId = table.Column<string>(nullable: false),
                    CommentId1 = table.Column<string>(nullable: true),
                    Dislike = table.Column<bool>(nullable: false),
                    Like = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Comments_CommentId1",
                        column: x => x.CommentId1,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Body = table.Column<string>(maxLength: 1000, nullable: false),
                    CommentId = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    ParentReplyId = table.Column<string>(nullable: true),
                    PostId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Replies_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReplyLikes",
                columns: table => new
                {
                    ReplyId = table.Column<string>(nullable: false),
                    Dislike = table.Column<bool>(nullable: false),
                    Like = table.Column<bool>(nullable: false),
                    ReplyId1 = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyLikes", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_ReplyLikes_Replies_ReplyId1",
                        column: x => x.ReplyId1,
                        principalTable: "Replies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_CommentId1",
                table: "CommentLikes",
                column: "CommentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_PostId",
                table: "PostCategories",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_PostId1",
                table: "PostLikes",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_PostVideos_PostId",
                table: "PostVideos",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CommentId",
                table: "Replies",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_PostId",
                table: "Replies",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyLikes_ReplyId1",
                table: "ReplyLikes",
                column: "ReplyId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "PostLikes");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "PostVideos");

            migrationBuilder.DropTable(
                name: "ReplyLikes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
