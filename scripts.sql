USE [master]
GO

/****** Object:  Database [IRMS]    Script Date: 3/19/2022 11:29:42 AM ******/
CREATE DATABASE [IRMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IRMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\IRMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IRMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\IRMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IRMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [IRMS] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [IRMS] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [IRMS] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [IRMS] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [IRMS] SET ARITHABORT OFF 
GO

ALTER DATABASE [IRMS] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [IRMS] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [IRMS] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [IRMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [IRMS] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [IRMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [IRMS] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [IRMS] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [IRMS] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [IRMS] SET  DISABLE_BROKER 
GO

ALTER DATABASE [IRMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [IRMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [IRMS] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [IRMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [IRMS] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [IRMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [IRMS] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [IRMS] SET RECOVERY FULL 
GO

ALTER DATABASE [IRMS] SET  MULTI_USER 
GO

ALTER DATABASE [IRMS] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [IRMS] SET DB_CHAINING OFF 
GO

ALTER DATABASE [IRMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [IRMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [IRMS] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [IRMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [IRMS] SET QUERY_STORE = OFF
GO

ALTER DATABASE [IRMS] SET  READ_WRITE 
GO


