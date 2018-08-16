namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NovelWeb : DbContext
    {
        public NovelWeb()
            : base("name=NovelWeb")
        {
        }

        public virtual DbSet<ATTENTION> ATTENTION { get; set; }
        public virtual DbSet<BOOK> BOOK { get; set; }
        public virtual DbSet<BOOKTAG> BOOKTAG { get; set; }
        public virtual DbSet<BROWSEHISTORY> BROWSEHISTORY { get; set; }
        public virtual DbSet<CHAPTER> CHAPTER { get; set; }
        public virtual DbSet<COLLECT> COLLECT { get; set; }
        public virtual DbSet<DOWNLOAD> DOWNLOAD { get; set; }
        public virtual DbSet<FRIEND> FRIEND { get; set; }
        public virtual DbSet<PUBLISHER> PUBLISHER { get; set; }
        public virtual DbSet<READER> READER { get; set; }
        public virtual DbSet<REVIEW> REVIEW { get; set; }
        public virtual DbSet<SIGNING> SIGNING { get; set; }
        public virtual DbSet<WRITER> WRITER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ATTENTION>()
                .Property(e => e.READERID)
                .IsUnicode(false);

            modelBuilder.Entity<ATTENTION>()
                .Property(e => e.WRITERID)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.BOOKID)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.BOOKNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.WRITERID)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.STARTTIME)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.UPDATETIME)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.DOWNLOADNUM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.COLLECTNUM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.IFEND)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.DOWNLOADLINK)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.PRICEPERCHAPTER)
                .HasPrecision(8, 2);

            modelBuilder.Entity<BOOKTAG>()
                .Property(e => e.BOOKID)
                .IsUnicode(false);

            modelBuilder.Entity<BOOKTAG>()
                .Property(e => e.BOOKTAG1)
                .IsUnicode(false);

            modelBuilder.Entity<BROWSEHISTORY>()
                .Property(e => e.READERID)
                .IsUnicode(false);

            modelBuilder.Entity<BROWSEHISTORY>()
                .Property(e => e.BOOKID)
                .IsUnicode(false);

            modelBuilder.Entity<BROWSEHISTORY>()
                .Property(e => e.CHAPTERID)
                .IsUnicode(false);

            modelBuilder.Entity<BROWSEHISTORY>()
                .Property(e => e.TIME)
                .IsUnicode(false);

            modelBuilder.Entity<CHAPTER>()
                .Property(e => e.BOOKID)
                .IsUnicode(false);

            modelBuilder.Entity<CHAPTER>()
                .Property(e => e.CHAPTERID)
                .IsUnicode(false);

            modelBuilder.Entity<CHAPTER>()
                .Property(e => e.CHAPTERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CHAPTER>()
                .Property(e => e.CHAPTERCONTENT)
                .IsUnicode(false);

            modelBuilder.Entity<COLLECT>()
                .Property(e => e.READERID)
                .IsUnicode(false);

            modelBuilder.Entity<COLLECT>()
                .Property(e => e.BOOKID)
                .IsUnicode(false);

            modelBuilder.Entity<DOWNLOAD>()
                .Property(e => e.READERID)
                .IsUnicode(false);

            modelBuilder.Entity<DOWNLOAD>()
                .Property(e => e.BOOKID)
                .IsUnicode(false);

            modelBuilder.Entity<FRIEND>()
                .Property(e => e.READERIDA)
                .IsUnicode(false);

            modelBuilder.Entity<FRIEND>()
                .Property(e => e.READERIDB)
                .IsUnicode(false);

            modelBuilder.Entity<PUBLISHER>()
                .Property(e => e.PUBLISHERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<PUBLISHER>()
                .Property(e => e.PUBLISHERLINK)
                .IsUnicode(false);

            modelBuilder.Entity<READER>()
                .Property(e => e.READERID)
                .IsUnicode(false);

            modelBuilder.Entity<READER>()
                .Property(e => e.READERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<READER>()
                .Property(e => e.SEX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<READER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<READER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<READER>()
                .Property(e => e.VIPREST)
                .HasPrecision(38, 0);

            modelBuilder.Entity<READER>()
                .Property(e => e.NUMCOLLECTBOOK)
                .HasPrecision(38, 0);

            modelBuilder.Entity<READER>()
                .Property(e => e.MONTHTICKET)
                .HasPrecision(38, 0);

            modelBuilder.Entity<REVIEW>()
                .Property(e => e.COMMENTID)
                .IsUnicode(false);

            modelBuilder.Entity<REVIEW>()
                .Property(e => e.FLOORNUMBER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<REVIEW>()
                .Property(e => e.BOOKID)
                .IsUnicode(false);

            modelBuilder.Entity<REVIEW>()
                .Property(e => e.CHAPTERID)
                .IsUnicode(false);

            modelBuilder.Entity<REVIEW>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<REVIEW>()
                .Property(e => e.CONTENT)
                .IsUnicode(false);

            modelBuilder.Entity<REVIEW>()
                .Property(e => e.REVIEWDATE)
                .IsUnicode(false);

            modelBuilder.Entity<SIGNING>()
                .Property(e => e.WRITERID)
                .IsUnicode(false);

            modelBuilder.Entity<SIGNING>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SIGNING>()
                .Property(e => e.STARTTIME)
                .IsUnicode(false);

            modelBuilder.Entity<SIGNING>()
                .Property(e => e.ENDTIME)
                .IsUnicode(false);

            modelBuilder.Entity<WRITER>()
                .Property(e => e.WRITERID)
                .IsUnicode(false);

            modelBuilder.Entity<WRITER>()
                .Property(e => e.WRITERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<WRITER>()
                .Property(e => e.SEX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<WRITER>()
                .Property(e => e.EMAI)
                .IsUnicode(false);

            modelBuilder.Entity<WRITER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<WRITER>()
                .Property(e => e.WRITERLEVEL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<WRITER>()
                .Property(e => e.NUMPRODUCTION)
                .HasPrecision(38, 0);

            modelBuilder.Entity<WRITER>()
                .Property(e => e.NUMFANS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<WRITER>()
                .Property(e => e.MONTHTICKET)
                .HasPrecision(38, 0);
        }
    }
}
