<?xml version="1.0"?> 
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:template match="/">
		<html>
		<head>
			<title>Driving License</title>
			<link rel="stylesheet" href="DrivingLicense.css"/>
		</head>
		<body>		
		 <table  border="1" style="width:36%; background-color:white; border-radius: 15px;">

		 	<div>
			 <img src="/Content/Photos/logo.jpg" />
				<table>
					<tr class="govbar">
						<xsl:value-of select="DrivingLicense/CountryName"/>
						<br/>
						<xsl:value-of select="DrivingLicense/StateName"/>
					</tr>
				</table>
				<img src="/Content/Photos/RTO.jpg" style="width:40pt; height:40pt; float:right;"/>	
				<div class="cardtopdetails">
						<table>
							<tr>
								<td><i>DL No : </i><b><xsl:value-of select="DrivingLicense/DLNumber"/></b></td>
								<xsl:text>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</xsl:text>
								<td><i>DOI : </i><b><xsl:value-of select="DrivingLicense/DOI"/></b></td>
							</tr>
							<tr>
								<td><i>Valid Till : </i><b><xsl:value-of select="DrivingLicense/ValidTill"/></b></td>
							</tr>
						</table>
				</div>
			</div>

			<div >
				<div class="section">
					<div><i>
							FORM 7<br/>
							RULE 16(2)
						</i>
					</div>
					<img  class="dlpic" src="/Content/Photos/metallica.jpg"/>
						<div class="dlpic">
							<br/>
							<img src="/Content/Photos/metallica.jpg" style="width:15pt; height:20pt; float:right"/>
						</div>
				</div>
							
				<img src="/Content/Photos/chip.jpg" style="width:50pt; height:40pt; margin-top:25px;margin-left:30px;"/>
				<div class="cardmiddetails">
					<br/>
					<div><i>AUTHORISATION TO DRIVE FOLLOWING CLASS <br/> OF VEHICLES THROUGHOUT INDIA</i></div>
					
					<table>
						<th style="font-weight:normal ;text-align:center"><i>COV</i></th>
						<th style="font-weight:normal ;text-align:center"><i>DOI</i></th>
						<tr>
							<td><b><xsl:value-of select="DrivingLicense/COV1"/></b></td>
							<td ><b><xsl:value-of select="DrivingLicense/DOI"/></b></td>
						</tr>
						<tr>
							<td><b><xsl:value-of select="DrivingLicense/COV2"/></b></td>
							<td><b><xsl:value-of select="DrivingLicense/DOI"/></b></td>
						</tr>
					</table>
					<br/>
				<br/>
			    </div>

				<div class="birthblooddetails">
					<span>
								<i style="word-spacing:3px">DOB : </i>
								<b ><xsl:value-of select="DrivingLicense/DOB"/></b>
								<xsl:text>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</xsl:text>
								<i style="word-spacing:3px">  BG : </i>
								<b><xsl:value-of select="DrivingLicense/BG"/></b>
							</span>
				</div>

				<div class="persondetails">	
						<i>NAME	:</i> <b><xsl:value-of select="DrivingLicense/Name"/></b><br/>
						<i>S/D/W of	:</i> <b><xsl:value-of select="DrivingLicense/FatherName"/></b><br/>
						<i>Add :</i><b><xsl:value-of select="DrivingLicense/Address"/></b>

				</div>	
			</div>

		<div>
			<div class="issuedetails">
					<br/>
				<i >PIN :</i>
				<b><xsl:value-of select="DrivingLicense/Pin"/></b><br/>
				<i>Signature and ID of <br/> Issung Authority: </i>
				<b><xsl:value-of select="DrivingLicense/IssuingId"/></b>		
			</div>
			<div class="cardbottomdetails">
				<i >Signature/Thumb <br/>Impression of Holder</i>
			</div>
		</div>
		</table>			
		</body>
		</html>
	</xsl:template>
</xsl:stylesheet>


