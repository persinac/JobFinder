using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IndeedDetails
{
    public string city { set; get; }
    public string cmp { set; get; }
    public string cmpesc { set; get; }
    public string cmpid { set; get; }
    public string cmplnk { set; get; }
    public string country { set; get; }
    public string efccid { set; get; }
    public string jk { set; get; }
    public string loc { set; get; }
    public string locid { set; get; }
    public string num { set; get; }
    public string rd { set; get; }
    public string srcid { set; get; }
    public string srcname { set; get; }
    public string title { set; get; }
    public string zip { set; get; }
    public string url { set; get; }
    public bool viewed { set; get; }
    public bool applied { set; get; }
    public int levelOfInterest { set; get; }
    public string qualified { set; get; }
    public bool clearance { set; get; }

    public void Copy(IndeedDetails item)
    {
        this.applied = item.applied;
        this.city = item.city;
        this.clearance = item.clearance;
        this.cmp = item.cmp;
        this.cmpesc = item.cmpesc;
        this.cmpid = item.cmpid;
        this.cmplnk = item.cmplnk;
        this.country = item.country;
        this.efccid = item.efccid;
        this.jk = item.jk;
        this.levelOfInterest = item.levelOfInterest;
        this.loc = item.loc;
        this.locid = item.locid;
        this.num = item.num;
        this.qualified = item.qualified;
        this.rd = item.rd;
        this.srcid = item.srcid;
        this.srcname = item.srcname;
        this.title = item.title;
        this.url = item.url;
        this.viewed = item.viewed;
        this.zip = item.zip;

    }

}
