using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace quested_backend.Entities
{
    public partial class QuestedContext : DbContext
    {
        public QuestedContext()
        {
        }

        public QuestedContext(DbContextOptions<QuestedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Episode> Episode { get; set; }
        public virtual DbSet<Pupil> Pupil { get; set; }
        public virtual DbSet<PupilInClass> PupilInClass { get; set; }
        public virtual DbSet<PupilInCourse> PupilInCourse { get; set; }
        public virtual DbSet<PupilInCourseAnswersQuestion> PupilInCourseAnswersQuestion { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<SchoolOwnsSeason> SchoolOwnsSeason { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("fk_class_teacher1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacher_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_teacher1");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.HasIndex(e => e.CourseId)
                    .HasName("fk_course_instance_course1_idx");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("fk_course_instance_teacher1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacher_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CourseNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course_instance_course1");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course_instance_teacher1");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SeasonId })
                    .HasName("PRIMARY");

                entity.ToTable("episode");

                entity.HasIndex(e => e.SeasonId)
                    .HasName("fk_episode_course1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeasonId)
                    .HasColumnName("season_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Episode)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_episode_course1");
            });

            modelBuilder.Entity<Pupil>(entity =>
            {
                entity.ToTable("pupil");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PupilInClass>(entity =>
            {
                entity.HasKey(e => new { e.PupilId, e.ClassId })
                    .HasName("PRIMARY");

                entity.ToTable("pupil_in_class");

                entity.HasIndex(e => e.ClassId)
                    .HasName("fk_pupil_has_class_class1_idx");

                entity.HasIndex(e => e.PupilId)
                    .HasName("fk_pupil_has_class_pupil1_idx");

                entity.Property(e => e.PupilId)
                    .HasColumnName("pupil_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClassId)
                    .HasColumnName("class_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.PupilInClass)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pupil_has_class_class1");

                entity.HasOne(d => d.Pupil)
                    .WithMany(p => p.PupilInClass)
                    .HasForeignKey(d => d.PupilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pupil_has_class_pupil1");
            });

            modelBuilder.Entity<PupilInCourse>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.PupilId })
                    .HasName("PRIMARY");

                entity.ToTable("pupil_in_course");

                entity.HasIndex(e => e.CourseId)
                    .HasName("fk_course_instance_has_pupil_course_instance1_idx");

                entity.HasIndex(e => e.PupilId)
                    .HasName("fk_course_instance_has_pupil_pupil1_idx");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PupilId)
                    .HasColumnName("pupil_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PupilInCourse)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course_instance_has_pupil_course_instance1");

                entity.HasOne(d => d.Pupil)
                    .WithMany(p => p.PupilInCourse)
                    .HasForeignKey(d => d.PupilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course_instance_has_pupil_pupil1");
            });

            modelBuilder.Entity<PupilInCourseAnswersQuestion>(entity =>
            {
                entity.HasKey(e => new { e.PupilInCourseCourseId, e.PupilInCoursePupilId, e.QuestionId, e.QuestionEpisodeId, e.QuestionEpisodeSeasonId })
                    .HasName("PRIMARY");

                entity.ToTable("pupil_in_course_answers_question");

                entity.HasIndex(e => new { e.PupilInCourseCourseId, e.PupilInCoursePupilId })
                    .HasName("fk_pupil_in_course_has_question_pupil_in_course1_idx");

                entity.HasIndex(e => new { e.QuestionId, e.QuestionEpisodeId, e.QuestionEpisodeSeasonId })
                    .HasName("fk_pupil_in_course_has_question_question1_idx");

                entity.Property(e => e.PupilInCourseCourseId)
                    .HasColumnName("pupil_in_course_course_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PupilInCoursePupilId)
                    .HasColumnName("pupil_in_course_pupil_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionEpisodeId)
                    .HasColumnName("question_episode_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionEpisodeSeasonId)
                    .HasColumnName("question_episode_season_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AchievedPoints)
                    .HasColumnName("achieved_points")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.PupilInCourse)
                    .WithMany(p => p.PupilInCourseAnswersQuestion)
                    .HasForeignKey(d => new { d.PupilInCourseCourseId, d.PupilInCoursePupilId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pupil_in_course_has_question_pupil_in_course1");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.PupilInCourseAnswersQuestion)
                    .HasForeignKey(d => new { d.QuestionId, d.QuestionEpisodeId, d.QuestionEpisodeSeasonId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pupil_in_course_has_question_question1");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.EpisodeId, e.EpisodeSeasonId })
                    .HasName("PRIMARY");

                entity.ToTable("question");

                entity.HasIndex(e => new { e.EpisodeId, e.EpisodeSeasonId })
                    .HasName("fk_question_episode1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EpisodeId)
                    .HasColumnName("episode_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EpisodeSeasonId)
                    .HasColumnName("episode_season_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaxPoints)
                    .HasColumnName("max_points")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Episode)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => new { d.EpisodeId, d.EpisodeSeasonId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_question_episode1");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("school");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SchoolOwnsSeason>(entity =>
            {
                entity.HasKey(e => new { e.SeasonId, e.SchoolId })
                    .HasName("PRIMARY");

                entity.ToTable("school_owns_season");

                entity.HasIndex(e => e.SchoolId)
                    .HasName("fk_season_has_school_school1_idx");

                entity.HasIndex(e => e.SeasonId)
                    .HasName("fk_season_has_school_season1_idx");

                entity.Property(e => e.SeasonId)
                    .HasColumnName("season_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SchoolId)
                    .HasColumnName("school_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.SchoolOwnsSeason)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_season_has_school_school1");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.SchoolOwnsSeason)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_season_has_school_season1");
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.ToTable("season");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.HasIndex(e => e.SchoolId)
                    .HasName("fk_teacher_school1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolId)
                    .HasColumnName("school_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_teacher_school1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
