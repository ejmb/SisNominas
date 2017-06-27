USE [Nomina_TP]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 24/5/2017 3:34:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargo](
	[ID_Cargo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_Cargo] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[ID_Cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dia_Libre]    Script Date: 24/5/2017 3:34:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dia_Libre](
	[ID_Dia_Libre] [int] IDENTITY(1,1) NOT NULL,
	[Empleado_ID] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Dia_Libre] PRIMARY KEY CLUSTERED 
(
	[ID_Dia_Libre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 24/5/2017 3:34:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[ID_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](255) NOT NULL,
	[Apellidos] [varchar](255) NOT NULL,
	[Direccion] [varchar](255) NOT NULL,
	[Nro_Documento] [varchar](50) NOT NULL,
	[Tipo_Documento] [varchar](20) NOT NULL,
	[Nro_Celular] [varchar](50) NOT NULL,
	[Fecha_Ingreso] [datetime] NOT NULL,
	[Cargo_Actual_ID] [int] NULL,
	[Dias_Vacaciones_Acumulados] [int] NULL,
	[Dias_Libres_Acumulados] [int] NULL,
	[Estado] [varchar](50) NULL,
	[Salario_Base_Actual] [int] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[ID_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uniq_nroDocEmpleado] UNIQUE NONCLUSTERED 
(
	[Nro_Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Historico_Cargo_Empleado]    Script Date: 24/5/2017 3:34:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historico_Cargo_Empleado](
	[ID_Historico] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Cambio] [datetime] NOT NULL,
	[Empleado_ID] [int] NOT NULL,
	[Cargo_Anterior_ID] [int] NOT NULL,
	[Cargo_Nuevo_ID] [int] NOT NULL,
	[Nuevo_Salario] [int] NOT NULL,
 CONSTRAINT [PK_Historico_Cargo_Empleado] PRIMARY KEY CLUSTERED 
(
	[ID_Historico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Llegada_Tardia]    Script Date: 24/5/2017 3:34:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Llegada_Tardia](
	[ID_Llegada_Tardia] [int] IDENTITY(1,1) NOT NULL,
	[Empleado_ID] [int] NOT NULL,
	[Horas_Minutos_Diferencia] [time](7) NOT NULL,
 CONSTRAINT [PK_Llegada_Tardia] PRIMARY KEY CLUSTERED 
(
	[ID_Llegada_Tardia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Marcacion]    Script Date: 24/5/2017 3:34:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcacion](
	[ID_Marcacion] [bigint] IDENTITY(1,1) NOT NULL,
	[Empleado_ID] [int] NOT NULL,
	[Fecha_Hora] [datetime] NOT NULL,
 CONSTRAINT [PK_Marcacion] PRIMARY KEY CLUSTERED 
(
	[ID_Marcacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parametros_Sistema]    Script Date: 24/5/2017 3:34:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros_Sistema](
	[ID_Parametro] [int] IDENTITY(1,1) NOT NULL,
	[Horario_Entrada] [time](7) NOT NULL,
	[Horario_Salida] [time](7) NOT NULL,
	[Minutos_Tolerancia] [int] NOT NULL,
	[Cantidad_Maxima_Dias_Vacaciones] [int] NOT NULL,
 CONSTRAINT [PK_Parametros_Sistema] PRIMARY KEY CLUSTERED 
(
	[ID_Parametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Planificacion_Horas_Extras]    Script Date: 24/5/2017 3:34:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planificacion_Horas_Extras](
	[ID_Hora_Extra_Planificada] [int] IDENTITY(1,1) NOT NULL,
	[Empleado_ID] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cantidad_Horas] [int] NOT NULL,
	[Cantidad_Canjeada] [int] NOT NULL,
 CONSTRAINT [PK_Planificacion_Horas_Extras] PRIMARY KEY CLUSTERED 
(
	[ID_Hora_Extra_Planificada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reposo]    Script Date: 24/5/2017 3:34:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reposo](
	[ID_Reposo] [int] IDENTITY(1,1) NOT NULL,
	[Empleado_ID] [int] NOT NULL,
	[Motivo] [varchar](4000) NOT NULL,
	[Fecha_Desde] [datetime] NOT NULL,
	[Cantidad_Dias] [int] NOT NULL,
 CONSTRAINT [PK_Reposo] PRIMARY KEY CLUSTERED 
(
	[ID_Reposo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 24/5/2017 3:34:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](200) NOT NULL,
	[Clave] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [DF_Empleado_Dias_Vacaciones_Acumulados]  DEFAULT ((0)) FOR [Dias_Vacaciones_Acumulados]
GO
ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [DF_Empleado_Dias_Libres_Acumulados]  DEFAULT ((0)) FOR [Dias_Libres_Acumulados]
GO
ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [DF_Empleado_Salario_Base_Actual]  DEFAULT ((0)) FOR [Salario_Base_Actual]
GO
ALTER TABLE [dbo].[Dia_Libre]  WITH CHECK ADD  CONSTRAINT [FK_Dia_Libre_Empleado] FOREIGN KEY([Empleado_ID])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Dia_Libre] CHECK CONSTRAINT [FK_Dia_Libre_Empleado]
GO
ALTER TABLE [dbo].[Historico_Cargo_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Historico_Cargo_Empleado_Cargo_Ant] FOREIGN KEY([Cargo_Anterior_ID])
REFERENCES [dbo].[Cargo] ([ID_Cargo])
GO
ALTER TABLE [dbo].[Historico_Cargo_Empleado] CHECK CONSTRAINT [FK_Historico_Cargo_Empleado_Cargo_Ant]
GO
ALTER TABLE [dbo].[Historico_Cargo_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Historico_Cargo_Empleado_Cargo_Nue] FOREIGN KEY([Cargo_Nuevo_ID])
REFERENCES [dbo].[Cargo] ([ID_Cargo])
GO
ALTER TABLE [dbo].[Historico_Cargo_Empleado] CHECK CONSTRAINT [FK_Historico_Cargo_Empleado_Cargo_Nue]
GO
ALTER TABLE [dbo].[Historico_Cargo_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Historico_Cargo_Empleado_Empleado] FOREIGN KEY([Empleado_ID])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Historico_Cargo_Empleado] CHECK CONSTRAINT [FK_Historico_Cargo_Empleado_Empleado]
GO
ALTER TABLE [dbo].[Llegada_Tardia]  WITH CHECK ADD  CONSTRAINT [FK_Llegada_Tardia_Empleado] FOREIGN KEY([Empleado_ID])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Llegada_Tardia] CHECK CONSTRAINT [FK_Llegada_Tardia_Empleado]
GO
ALTER TABLE [dbo].[Marcacion]  WITH CHECK ADD  CONSTRAINT [FK_Marcacion_Empleado] FOREIGN KEY([Empleado_ID])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Marcacion] CHECK CONSTRAINT [FK_Marcacion_Empleado]
GO
ALTER TABLE [dbo].[Planificacion_Horas_Extras]  WITH CHECK ADD  CONSTRAINT [FK_Planificacion_Horas_Extras_Empleado] FOREIGN KEY([Empleado_ID])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Planificacion_Horas_Extras] CHECK CONSTRAINT [FK_Planificacion_Horas_Extras_Empleado]
GO
ALTER TABLE [dbo].[Reposo]  WITH CHECK ADD  CONSTRAINT [FK_Reposo_Empleado] FOREIGN KEY([Empleado_ID])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Reposo] CHECK CONSTRAINT [FK_Reposo_Empleado]
GO