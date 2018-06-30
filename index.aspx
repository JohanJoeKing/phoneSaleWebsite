<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/JavaScript">
<!--
function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
</script>
</head>
<body onLoad="MM_preloadImages('image/homepage/dpt1.png','image/homepage/dpt2.png','image/homepage/dpt3.png','image/homepage/dpt4.png','image/homepage/dpt5.png')">
    <form id="form1" runat="server">
      <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="150" colspan="5"><img src="image/homepage/head.png" width="1000" height="150"></td>
        </tr>
        <tr>
          <td width="200"><a href="purchaseadd.aspx" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image3','','image/homepage/dpt1.png',1)"><img src="image/homepage/dpt12.png" name="Image3" width="200" height="400" border="0"></a></td>
          <td width="200"><a href="sale.aspx" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image4','','image/homepage/dpt2.png',1)"><img src="image/homepage/dpt22.png" name="Image4" width="200" height="400" border="0"></a></td>
          <td width="200"><a href="storequery.aspx" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image8','','image/homepage/dpt3.png',1)"><img src="image/homepage/dpt32.png" name="Image8" width="200" height="400" border="0"></a><a href="storequery.aspx"></a></td>
          <td width="200"><a href="financeHome.aspx" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image6','','image/homepage/dpt4.png',1)"><img src="image/homepage/dpt42.png" name="Image6" width="200" height="400" border="0"></a></td>
          <td width="200"><a href="systemHome.aspx" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image7','','image/homepage/dpt5.png',1)"><img src="image/homepage/dpt52.png" name="Image7" width="200" height="400" border="0"></a></td>
        </tr>
        <tr>
          <td colspan="5"><img src="image/homepage/tail.png" width="1000" height="150"></td>
        </tr>
      </table>
	
    </form>
</body>
</html>
