﻿CREATE PROC FI_SP_VerificaCliente
	@CPF			VARCHAR(11)
AS
BEGIN
	SELECT * FROM CLIENTES WHERE CPF = @CPF
END