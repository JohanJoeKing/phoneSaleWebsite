using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : Phone.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/27
 * - Description : 手机实体类
 * - Function list :
 * 1.Phone
 * -Others : 
 * [刘畅]2018/5/27第一次修改，搭建好类
 ***************************************************/


/// <summary>
/// Phone 的摘要说明
/// </summary>
public class Phone
{
    private string id;           //商品编号
    private string brand;        //品牌
    private string model;        //型号
    private string date;         //上市年份
    private double width;        //机身宽度
    private double length;       //机身长度
    private double thickness;    //机身厚度
    private double weight;       //机身重量
    private string color;        //机身颜色
    private string battery;      //电池容量
    private string camera_b;     //后置相机像素
    private string camera_f;     //前置相机像素
    private string rom;          //ROM
    private string ram;          //RAM
    private string cpuModel;     //CPU型号
    private string cpuBrand;     //CPU品牌
    private string os;           //操作系统
    private string screenSize;   //屏幕尺寸
    private string ratio;        //分辨率
    private string priceBuy;     //进货价
    private string priceSale;    //售价



    // set
    public void setId(string id) { this.id = id; }
    public void setBrand(string brand) { this.brand = brand; }
    public void setModel(string model) { this.model = model; }
    public void setDate(string date) { this.date = date; }
    public void setWidth(double width) { this.width = width; }
    public void setLength(double length) { this.length = length; }
    public void setThickness(double thickness) { this.thickness = thickness; }
    public void setWeight(double weight) { this.weight = weight; }
    public void setColor(string color) { this.color = color; }
    public void setBattery(string battery) { this.battery = battery; }
    public void setCamera_b(string camera_b) { this.camera_b = camera_b; }
    public void setCamera_f(string camera_f) { this.camera_f = camera_f; }
    public void setRom(string rom) { this.rom = rom; }
    public void setRam(string ram) { this.ram = ram; }
    public void setCpuModel(string cpuModel) { this.cpuModel = cpuModel; }
    public void setCpuBrand(string cpuBrand) { this.cpuBrand = cpuBrand; }
    public void setOs(string os) { this.os = os; }
    public void setScreenSize(string screenSize) { this.screenSize = screenSize; }
    public void setRatio(string ratio) { this.ratio = ratio; }
    public void setPriceBuy(string priceBuy) { this.priceBuy = priceBuy; }
    public void setPriceSale(string priceSale) { this.priceSale = priceSale; }



    // get
    public string getId() { return id; }
    public string getBrand() { return brand; }
    public string getModel() { return model; }
    public string getDate() { return date; }
    public double getWidth() { return width; }
    public double getLength() { return length; }
    public double getThickness() { return thickness; }
    public double getWeight() { return weight; }
    public string getColor() { return color; }
    public string getBattery() { return battery; }
    public string getCamera_b() { return camera_b; }
    public string getCamera_f() { return camera_f; }
    public string getRam() { return ram; }
    public string getRom() { return rom; }
    public string getCpuModel() { return cpuModel; }
    public string getCpuBrand() { return cpuBrand; }
    public string getOs() { return os; }
    public string getScreenSize() { return screenSize; }
    public string getRatio() { return ratio; }
    public string getPriceBuy() { return priceBuy; }
    public string getPriceSale() { return priceSale; }




    /*****************************************************
    * - Function name : Phone
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public Phone()
	{
		
	}
}