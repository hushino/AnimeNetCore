﻿// <auto-generated />
using AnimeNetCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AnimeNetCore.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20171230013926_Unamigracion")]
    partial class Unamigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnimeNetCore.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Checked");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UrlSeo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AnimeNetCore.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime>("DateTime");

                    b.Property<bool>("Deleted");

                    b.Property<int>("NetLikeCount");

                    b.Property<string>("PostId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AnimeNetCore.Models.CommentLike", b =>
                {
                    b.Property<string>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentId1");

                    b.Property<bool>("Dislike");

                    b.Property<bool>("Like");

                    b.Property<string>("Username");

                    b.HasKey("CommentId");

                    b.HasIndex("CommentId1");

                    b.ToTable("CommentLikes");
                });

            modelBuilder.Entity("AnimeNetCore.Models.Post", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("Meta")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("Modified");

                    b.Property<int>("NetLikeCount");

                    b.Property<DateTime>("PostedOn");

                    b.Property<bool>("Published");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UrlSeo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("AnimeNetCore.Models.PostCategory", b =>
                {
                    b.Property<string>("CategotyId");

                    b.Property<string>("PostId");

                    b.Property<string>("CategoryId");

                    b.Property<bool>("Checked");

                    b.HasKey("CategotyId", "PostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("AnimeNetCore.Models.PostLike", b =>
                {
                    b.Property<string>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Dislike");

                    b.Property<bool>("Like");

                    b.Property<string>("PostId1");

                    b.Property<string>("Username");

                    b.HasKey("PostId");

                    b.HasIndex("PostId1");

                    b.ToTable("PostLikes");
                });

            modelBuilder.Entity("AnimeNetCore.Models.PostTag", b =>
                {
                    b.Property<string>("PostId");

                    b.Property<string>("TagId");

                    b.Property<bool>("Checked");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("AnimeNetCore.Models.PostVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PostId");

                    b.Property<string>("VideoSiteName");

                    b.Property<string>("VideoThumbnail");

                    b.Property<string>("VideoUrl")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostVideos");
                });

            modelBuilder.Entity("AnimeNetCore.Models.Reply", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("CommentId");

                    b.Property<DateTime>("DateTime");

                    b.Property<bool>("Deleted");

                    b.Property<string>("ParentReplyId");

                    b.Property<string>("PostId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("AnimeNetCore.Models.ReplyLike", b =>
                {
                    b.Property<string>("ReplyId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Dislike");

                    b.Property<bool>("Like");

                    b.Property<string>("ReplyId1");

                    b.Property<string>("Username");

                    b.HasKey("ReplyId");

                    b.HasIndex("ReplyId1");

                    b.ToTable("ReplyLikes");
                });

            modelBuilder.Entity("AnimeNetCore.Models.Tag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Checked");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UrlSeo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("AnimeNetCore.Models.Comment", b =>
                {
                    b.HasOne("AnimeNetCore.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("AnimeNetCore.Models.CommentLike", b =>
                {
                    b.HasOne("AnimeNetCore.Models.Comment", "Comment")
                        .WithMany("CommentLikes")
                        .HasForeignKey("CommentId1");
                });

            modelBuilder.Entity("AnimeNetCore.Models.PostCategory", b =>
                {
                    b.HasOne("AnimeNetCore.Models.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("AnimeNetCore.Models.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AnimeNetCore.Models.PostLike", b =>
                {
                    b.HasOne("AnimeNetCore.Models.Post", "Post")
                        .WithMany("PostLikes")
                        .HasForeignKey("PostId1");
                });

            modelBuilder.Entity("AnimeNetCore.Models.PostTag", b =>
                {
                    b.HasOne("AnimeNetCore.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AnimeNetCore.Models.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AnimeNetCore.Models.PostVideo", b =>
                {
                    b.HasOne("AnimeNetCore.Models.Post", "Post")
                        .WithMany("PostVideos")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("AnimeNetCore.Models.Reply", b =>
                {
                    b.HasOne("AnimeNetCore.Models.Comment", "Comment")
                        .WithMany("Replies")
                        .HasForeignKey("CommentId");

                    b.HasOne("AnimeNetCore.Models.Post", "Post")
                        .WithMany("Replies")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("AnimeNetCore.Models.ReplyLike", b =>
                {
                    b.HasOne("AnimeNetCore.Models.Reply", "Reply")
                        .WithMany("ReplyLikes")
                        .HasForeignKey("ReplyId1");
                });
#pragma warning restore 612, 618
        }
    }
}
