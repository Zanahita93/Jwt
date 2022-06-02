USE [master]
GO

/****** Object:  Database [Jwt_DB]    Script Date: 6/2/2022 3:09:09 AM ******/
CREATE DATABASE [Jwt_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Jwt_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Jwt_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Jwt_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Jwt_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Jwt_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Jwt_DB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Jwt_DB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Jwt_DB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Jwt_DB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Jwt_DB] SET ARITHABORT OFF 
GO

ALTER DATABASE [Jwt_DB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Jwt_DB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Jwt_DB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Jwt_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Jwt_DB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Jwt_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Jwt_DB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Jwt_DB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Jwt_DB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Jwt_DB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Jwt_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Jwt_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Jwt_DB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Jwt_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Jwt_DB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Jwt_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Jwt_DB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Jwt_DB] SET RECOVERY FULL 
GO

ALTER DATABASE [Jwt_DB] SET  MULTI_USER 
GO

ALTER DATABASE [Jwt_DB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Jwt_DB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Jwt_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Jwt_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Jwt_DB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Jwt_DB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Jwt_DB] SET  READ_WRITE 
GO
