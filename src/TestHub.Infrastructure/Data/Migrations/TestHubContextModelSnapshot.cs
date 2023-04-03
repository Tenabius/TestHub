﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestHub.Infrastructure.Data;

#nullable disable

namespace TestHub.Infrastructure.Data.Migrations
{
    [DbContext(typeof(TestHubContext))]
    partial class TestHubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnswersSheetId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswersSheetId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TestHub.Core.Entities.AnswersSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("TestId");

                    b.ToTable("AnswersSheets", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankAnswer+SubmittedBlank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlankId")
                        .HasColumnType("int");

                    b.Property<int?>("FillBlankAnswerId")
                        .HasColumnType("int");

                    b.Property<string>("SubmittedAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlankId");

                    b.HasIndex("FillBlankAnswerId");

                    b.ToTable("SubmittedBlank", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankQuestion+Blank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FillBlankQuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FillBlankQuestionId");

                    b.ToTable("Blank", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingAnswer+SubmittedResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MatchingAnswerId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponseId")
                        .HasColumnType("int");

                    b.Property<int>("StemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchingAnswerId");

                    b.HasIndex("ResponseId");

                    b.HasIndex("StemId");

                    b.ToTable("SubmittedResponse", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingQuestion+Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Response", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingQuestion+Stem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MatchingQuestionId")
                        .HasColumnType("int");

                    b.Property<int>("ResponseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchingQuestionId");

                    b.HasIndex("ResponseId");

                    b.ToTable("Stem", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceAnswer+SubmittedChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<int?>("MultipleChoiceAnswerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceId");

                    b.HasIndex("MultipleChoiceAnswerId");

                    b.ToTable("SubmittedChoice", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceQuestion+Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int?>("MultipleChoiceQuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MultipleChoiceQuestionId");

                    b.ToTable("Choice", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Directions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Question", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TestHub.Core.Entities.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttemptAllowed")
                        .HasColumnType("int");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("PassingScore")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Tests", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.FalseTrueAnswer", b =>
                {
                    b.HasBaseType("TestHub.Core.Entities.Answer");

                    b.Property<bool?>("SubmittedChoice")
                        .HasColumnType("bit");

                    b.ToTable("FalseTrueAnswer", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankAnswer", b =>
                {
                    b.HasBaseType("TestHub.Core.Entities.Answer");

                    b.ToTable("FillBlankAnswer", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingAnswer", b =>
                {
                    b.HasBaseType("TestHub.Core.Entities.Answer");

                    b.ToTable("MatchingAnswer", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceAnswer", b =>
                {
                    b.HasBaseType("TestHub.Core.Entities.Answer");

                    b.ToTable("MultipleChoiceAnswer", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.FalseTrueQuestion", b =>
                {
                    b.HasBaseType("TestHub.Core.Entities.Question");

                    b.Property<bool>("CorrectChoice")
                        .HasColumnType("bit");

                    b.Property<string>("Statement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FalseTrueQuestion", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankQuestion", b =>
                {
                    b.HasBaseType("TestHub.Core.Entities.Question");

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FillBlankQuestion", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingQuestion", b =>
                {
                    b.HasBaseType("TestHub.Core.Entities.Question");

                    b.ToTable("MatchingQuestion", (string)null);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceQuestion", b =>
                {
                    b.HasBaseType("TestHub.Core.Entities.Question");

                    b.Property<bool>("IsMultipleAnswers")
                        .HasColumnType("bit");

                    b.Property<string>("Stem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("MultipleChoiceQuestion", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestHub.Core.Entities.Answer", b =>
                {
                    b.HasOne("TestHub.Core.Entities.AnswersSheet", null)
                        .WithMany("SubmittedAnswers")
                        .HasForeignKey("AnswersSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestHub.Core.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TestHub.Core.Entities.AnswersSheet", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestHub.Core.Entities.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankAnswer+SubmittedBlank", b =>
                {
                    b.HasOne("TestHub.Core.Entities.FillBlankQuestion+Blank", "Blank")
                        .WithMany()
                        .HasForeignKey("BlankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestHub.Core.Entities.FillBlankAnswer", null)
                        .WithMany("SubmittedBlanks")
                        .HasForeignKey("FillBlankAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Blank");
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankQuestion+Blank", b =>
                {
                    b.HasOne("TestHub.Core.Entities.FillBlankQuestion", null)
                        .WithMany("Blanks")
                        .HasForeignKey("FillBlankQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingAnswer+SubmittedResponse", b =>
                {
                    b.HasOne("TestHub.Core.Entities.MatchingAnswer", null)
                        .WithMany("SubmittedResponses")
                        .HasForeignKey("MatchingAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestHub.Core.Entities.MatchingQuestion+Response", "Response")
                        .WithMany()
                        .HasForeignKey("ResponseId");

                    b.HasOne("TestHub.Core.Entities.MatchingQuestion+Stem", "Stem")
                        .WithMany()
                        .HasForeignKey("StemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Response");

                    b.Navigation("Stem");
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingQuestion+Stem", b =>
                {
                    b.HasOne("TestHub.Core.Entities.MatchingQuestion", null)
                        .WithMany("Stems")
                        .HasForeignKey("MatchingQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestHub.Core.Entities.MatchingQuestion+Response", "Response")
                        .WithMany()
                        .HasForeignKey("ResponseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Response");
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceAnswer+SubmittedChoice", b =>
                {
                    b.HasOne("TestHub.Core.Entities.MultipleChoiceQuestion+Choice", "Choice")
                        .WithMany()
                        .HasForeignKey("ChoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestHub.Core.Entities.MultipleChoiceAnswer", null)
                        .WithMany("SubmittedChoices")
                        .HasForeignKey("MultipleChoiceAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Choice");
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceQuestion+Choice", b =>
                {
                    b.HasOne("TestHub.Core.Entities.MultipleChoiceQuestion", null)
                        .WithMany("Choices")
                        .HasForeignKey("MultipleChoiceQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestHub.Core.Entities.Question", b =>
                {
                    b.HasOne("TestHub.Core.Entities.Test", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestHub.Core.Entities.Test", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("TestHub.Core.Entities.FalseTrueAnswer", b =>
                {
                    b.HasOne("TestHub.Core.Entities.Answer", null)
                        .WithOne()
                        .HasForeignKey("TestHub.Core.Entities.FalseTrueAnswer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankAnswer", b =>
                {
                    b.HasOne("TestHub.Core.Entities.Answer", null)
                        .WithOne()
                        .HasForeignKey("TestHub.Core.Entities.FillBlankAnswer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingAnswer", b =>
                {
                    b.HasOne("TestHub.Core.Entities.Answer", null)
                        .WithOne()
                        .HasForeignKey("TestHub.Core.Entities.MatchingAnswer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceAnswer", b =>
                {
                    b.HasOne("TestHub.Core.Entities.Answer", null)
                        .WithOne()
                        .HasForeignKey("TestHub.Core.Entities.MultipleChoiceAnswer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestHub.Core.Entities.FalseTrueQuestion", b =>
                {
                    b.HasOne("TestHub.Core.Entities.Question", null)
                        .WithOne()
                        .HasForeignKey("TestHub.Core.Entities.FalseTrueQuestion", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankQuestion", b =>
                {
                    b.HasOne("TestHub.Core.Entities.Question", null)
                        .WithOne()
                        .HasForeignKey("TestHub.Core.Entities.FillBlankQuestion", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingQuestion", b =>
                {
                    b.HasOne("TestHub.Core.Entities.Question", null)
                        .WithOne()
                        .HasForeignKey("TestHub.Core.Entities.MatchingQuestion", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceQuestion", b =>
                {
                    b.HasOne("TestHub.Core.Entities.Question", null)
                        .WithOne()
                        .HasForeignKey("TestHub.Core.Entities.MultipleChoiceQuestion", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestHub.Core.Entities.AnswersSheet", b =>
                {
                    b.Navigation("SubmittedAnswers");
                });

            modelBuilder.Entity("TestHub.Core.Entities.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankAnswer", b =>
                {
                    b.Navigation("SubmittedBlanks");
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingAnswer", b =>
                {
                    b.Navigation("SubmittedResponses");
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceAnswer", b =>
                {
                    b.Navigation("SubmittedChoices");
                });

            modelBuilder.Entity("TestHub.Core.Entities.FillBlankQuestion", b =>
                {
                    b.Navigation("Blanks");
                });

            modelBuilder.Entity("TestHub.Core.Entities.MatchingQuestion", b =>
                {
                    b.Navigation("Stems");
                });

            modelBuilder.Entity("TestHub.Core.Entities.MultipleChoiceQuestion", b =>
                {
                    b.Navigation("Choices");
                });
#pragma warning restore 612, 618
        }
    }
}
