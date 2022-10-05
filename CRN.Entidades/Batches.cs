using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Batches
{
	private string p_FBC_BATCH;
	private string p_FBC_BATCH_FATHER;
	private string p_FBC_PRODUCT_GROUP;
	private string p_FBC_PRODUCT_CODE;
	private string p_FBC_PRODUCT_DESC;
	private string p_FBC_FEATURE_GROUP;
	private string p_FBC_WORKCENTER;
	private string p_FBC_PO;
	private decimal p_FBC_WEIGHT;
	private int p_FBC_PIECE;
	private decimal p_FBC_METERS;
	private DateTime p_FBC_START;
	private DateTime p_FBC_END;
	private DateTime p_FBC_INS_DATE;
	private string p_FBC_ISSUE;
	private string p_FBC_BATCH_LABEL_1;
	private string p_FBC_BATCH_LABEL_2;
	private string p_FBC_MACHINE;
	private decimal p_FBC_QUANTITY;
	private string p_FBC_QTY_UM;

	public string FBC_BATCH
	{
		get { return p_FBC_BATCH; }
		set { p_FBC_BATCH = value; }
	}
	public string FBC_BATCH_FATHER
	{
		get { return p_FBC_BATCH_FATHER; }
		set { p_FBC_BATCH_FATHER = value; }
	}
	public string FBC_PRODUCT_GROUP
	{
		get { return p_FBC_PRODUCT_GROUP; }
		set { p_FBC_PRODUCT_GROUP = value; }
	}
	public string FBC_PRODUCT_CODE
	{
		get { return p_FBC_PRODUCT_CODE; }
		set { p_FBC_PRODUCT_CODE = value; }
	}
	public string FBC_PRODUCT_VERSION
	{
		get { return p_FBC_PRODUCT_VERSION; }
		set { p_FBC_PRODUCT_VERSION = value; }
	}
	public string FBC_PRODUCT_DESC
	{
		get { return p_FBC_PRODUCT_DESC; }
		set { p_FBC_PRODUCT_DESC = value; }
	}
	public string FBC_FEATURE_GROUP
	{
		get { return p_FBC_FEATURE_GROUP; }
		set { p_FBC_FEATURE_GROUP = value; }
	}
	public string FBC_WORKCENTER
	{
		get { return p_FBC_WORKCENTER; }
		set { p_FBC_WORKCENTER = value; }
	}
	public string FBC_PO
	{
		get { return p_FBC_PO; }
		set { p_FBC_PO = value; }
	}
	public decimal FBC_WEIGHT
	{
		get { return p_FBC_WEIGHT; }
		set { p_FBC_WEIGHT = value; }
	}
	public int FBC_PIECE
	{
		get { return p_FBC_PIECE; }
		set { p_FBC_PIECE = value; }
	}
	public decimal FBC_METERS
	{
		get { return p_FBC_METERS; }
		set { p_FBC_METERS = value; }
	}
	public DateTime FBC_START
	{
		get { return p_FBC_START; }
		set { p_FBC_START = value; }
	}
	public DateTime FBC_END
	{
		get { return p_FBC_END; }
		set { p_FBC_END = value; }
	}
	public DateTime FBC_INS_DATE
	{
		get { return p_FBC_INS_DATE; }
		set { p_FBC_INS_DATE = value; }
	}
	public string FBC_ISSUE
	{
		get { return p_FBC_ISSUE; }
		set { p_FBC_ISSUE = value; }
	}
	public string FBC_BATCH_LABEL_1
	{
		get { return p_FBC_BATCH_LABEL_1; }
		set { p_FBC_BATCH_LABEL_1 = value; }
	}
	public string FBC_BATCH_LABEL_2
	{
		get { return p_FBC_BATCH_LABEL_2; }
		set { p_FBC_BATCH_LABEL_2 = value; }
	}
	public string FBC_MACHINE
	{
		get { return p_FBC_MACHINE; }
		set { p_FBC_MACHINE = value; }
	}
	public decimal FBC_QUANTITY
	{
		get { return p_FBC_QUANTITY; }
		set { p_FBC_QUANTITY = value; }
	}
	public string FBC_QTY_UM
	{
		get { return p_FBC_QTY_UM; }
		set { p_FBC_QTY_UM = value; }
	}

}

