using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Consumido
{
	private string p_FCS_BATCH;
	private string p_FCS_WORKCENTER;
	private string p_FCS_MACHINE;
	private string p_FCS_PO;
	private string p_FCS_OPR;
	private decimal p_FCS_CONSUMED_QTY;
	private string p_FCS_QTY_UM;
	private DateTime p_FCS_START;
	private DateTime p_FCS_END;
	private int p_FCS_SEQUENCE;
	private string p_FCS_GROUP;
	private string p_FCS_OPERATOR;
	private string p_FCS_SHIFT;
	private string p_FCS_STATUS;
	private DateTime p_FCS_STATUS_DATE;
	private string p_FCS_BATCH_LABEL_1;
	private string p_FCS_PROGRAM;
	private string p_FCS_PROGRAM_ROW;

	public string FCS_BATCH
	{
		get { return p_FCS_BATCH; }
		set { p_FCS_BATCH = value; }
	}
	public string FCS_WORKCENTER
	{
		get { return p_FCS_WORKCENTER; }
		set { p_FCS_WORKCENTER = value; }
	}
	public string FCS_MACHINE
	{
		get { return p_FCS_MACHINE; }
		set { p_FCS_MACHINE = value; }
	}
	public string FCS_PO
	{
		get { return p_FCS_PO; }
		set { p_FCS_PO = value; }
	}
	public string FCS_OPR
	{
		get { return p_FCS_OPR; }
		set { p_FCS_OPR = value; }
	}
	public decimal FCS_CONSUMED_QTY
	{
		get { return p_FCS_CONSUMED_QTY; }
		set { p_FCS_CONSUMED_QTY = value; }
	}
	public string FCS_QTY_UM
	{
		get { return p_FCS_QTY_UM; }
		set { p_FCS_QTY_UM = value; }
	}
	public DateTime FCS_START
	{
		get { return p_FCS_START; }
		set { p_FCS_START = value; }
	}
	public DateTime FCS_END
	{
		get { return p_FCS_END; }
		set { p_FCS_END = value; }
	}
	public int FCS_SEQUENCE
	{
		get { return p_FCS_SEQUENCE; }
		set { p_FCS_SEQUENCE = value; }
	}
	public string FCS_GROUP
	{
		get { return p_FCS_GROUP; }
		set { p_FCS_GROUP = value; }
	}
	public string FCS_OPERATOR
	{
		get { return p_FCS_OPERATOR; }
		set { p_FCS_OPERATOR = value; }
	}
	public string FCS_SHIFT
	{
		get { return p_FCS_SHIFT; }
		set { p_FCS_SHIFT = value; }
	}
	public string FCS_STATUS
	{
		get { return p_FCS_STATUS; }
		set { p_FCS_STATUS = value; }
	}
	public DateTime FCS_STATUS_DATE
	{
		get { return p_FCS_STATUS_DATE; }
		set { p_FCS_STATUS_DATE = value; }
	}
	public string FCS_BATCH_LABEL_1
	{
		get { return p_FCS_BATCH_LABEL_1; }
		set { p_FCS_BATCH_LABEL_1 = value; }
	}
	public string FCS_PROGRAM
	{
		get { return p_FCS_PROGRAM; }
		set { p_FCS_PROGRAM = value; }
	}
	public string FCS_PROGRAM_ROW
	{
		get { return p_FCS_PROGRAM_ROW; }
		set { p_FCS_PROGRAM_ROW = value; }
	}

}

