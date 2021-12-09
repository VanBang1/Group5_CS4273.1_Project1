<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Family_tree_ouput.aspx.cs" Inherits="Group5_QLCGP.WebForm4" %>
  <!--#include file ="header.html"-->
<style>
ul, #myUL {
  list-style-type: none;
}

#myUL {
  margin: 0;
  padding: 0

}
.li{

      left: 50px;
  width: calc(30% - 30px);
  border: 1px solid black;
  background-color: yellow;
  padding: 15px;
}

.caret {
  cursor: pointer;
  -webkit-user-select: none; /* Safari 3.1+ */
  -moz-user-select: none; /* Firefox 2+ */
  -ms-user-select: none; /* IE 10+ */
  user-select: none;
  left: 50px;
  width: calc(30% - 30px);
  border: 1px solid black;
  background-color: green;
  padding: 5px;
}

.caret::before {
  content: "\25B6";
  color: black;
  display: inline-block;
  margin-right: 6px;
    padding: 10px;
  
}

.caret-down::before {
  -ms-transform: rotate(90deg); /* IE 9 */
  -webkit-transform: rotate(90deg); /* Safari */'
  transform: rotate(90deg);  
}

.nested {
  display: block;
}

.active {
  display: none;
}
    .auto-style1 {
        width: 1428px;
        height: 559px;
    }
</style>
</head>
<body>

<h2>Family Tree View</h2>
    The arrow(s) to open or close the tree branches.</p>
<ul id="myUL">
    <li class="auto-style1" style="font-size: 20px"><span class="caret">Ancestor</span>
<%Response.Write(html); %>
    
        </ul>
 

<script>
    var toggler = document.getElementsByClassName("caret");
    var i;

    for (i = 0; i < toggler.length; i++) {
        toggler[i].addEventListener("click", function () {
            this.parentElement.querySelector(".nested").classList.toggle("active");
            this.classList.toggle("caret-down");
        });
    }
</script>

</body>
</html>