USE [SMS]
GO

/****** Object:  StoredProcedure [dbo].[sp_update_customer]    Script Date: 11/18/2021 3:44:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create Proc [dbo].[sp_update_customer] (@id int, @name nvarchar(100))
as
	Update Customer
	set customer_name=@name
	where customer_id=@id
GO

