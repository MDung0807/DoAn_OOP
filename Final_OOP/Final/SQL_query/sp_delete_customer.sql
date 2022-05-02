USE [SMS]
GO

/****** Object:  StoredProcedure [dbo].[sp_delete_customer]    Script Date: 11/18/2021 3:42:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_delete_customer](@id int)
as
	delete from LineItem 
	where order_id in
	(select Orders.order_id 
	from Orders, Customer
	where Customer.customer_id=Orders.customer_id and Customer.customer_id=@id)
	delete from Orders where customer_id=@id
	delete from Customer where customer_id=@id 
	rollback
GO

