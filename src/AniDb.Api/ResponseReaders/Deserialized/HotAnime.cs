﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.17929.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class hotanime {
    
    private hotanimeAnime[] animeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("anime")]
    public hotanimeAnime[] anime {
        get {
            return this.animeField;
        }
        set {
            this.animeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class hotanimeAnime {
    
    private byte episodecountField;
    
    private bool episodecountFieldSpecified;
    
    private System.DateTime startdateField;
    
    private System.DateTime enddateField;
    
    private bool enddateFieldSpecified;
    
    private hotanimeAnimeTitle titleField;
    
    private hotanimeAnimeRatings ratingsField;
    
    private string pictureField;
    
    private ushort idField;
    
    private bool restrictedField;
    
    /// <remarks/>
    public byte episodecount {
        get {
            return this.episodecountField;
        }
        set {
            this.episodecountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool episodecountSpecified {
        get {
            return this.episodecountFieldSpecified;
        }
        set {
            this.episodecountFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
    public System.DateTime startdate {
        get {
            return this.startdateField;
        }
        set {
            this.startdateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
    public System.DateTime enddate {
        get {
            return this.enddateField;
        }
        set {
            this.enddateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool enddateSpecified {
        get {
            return this.enddateFieldSpecified;
        }
        set {
            this.enddateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public hotanimeAnimeTitle title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }
    
    /// <remarks/>
    public hotanimeAnimeRatings ratings {
        get {
            return this.ratingsField;
        }
        set {
            this.ratingsField = value;
        }
    }
    
    /// <remarks/>
    public string picture {
        get {
            return this.pictureField;
        }
        set {
            this.pictureField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool restricted {
        get {
            return this.restrictedField;
        }
        set {
            this.restrictedField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class hotanimeAnimeTitle {
    
    private string typeField;
    
    private string langField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://www.w3.org/XML/1998/namespace")]
    public string lang {
        get {
            return this.langField;
        }
        set {
            this.langField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class hotanimeAnimeRatings {
    
    private hotanimeAnimeRatingsPermanent permanentField;
    
    private hotanimeAnimeRatingsTemporary temporaryField;
    
    private hotanimeAnimeRatingsReview reviewField;
    
    /// <remarks/>
    public hotanimeAnimeRatingsPermanent permanent {
        get {
            return this.permanentField;
        }
        set {
            this.permanentField = value;
        }
    }
    
    /// <remarks/>
    public hotanimeAnimeRatingsTemporary temporary {
        get {
            return this.temporaryField;
        }
        set {
            this.temporaryField = value;
        }
    }
    
    /// <remarks/>
    public hotanimeAnimeRatingsReview review {
        get {
            return this.reviewField;
        }
        set {
            this.reviewField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class hotanimeAnimeRatingsPermanent {
    
    private ushort countField;
    
    private decimal valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort count {
        get {
            return this.countField;
        }
        set {
            this.countField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class hotanimeAnimeRatingsTemporary {
    
    private ushort countField;
    
    private decimal valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort count {
        get {
            return this.countField;
        }
        set {
            this.countField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class hotanimeAnimeRatingsReview {
    
    private byte countField;
    
    private decimal valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte count {
        get {
            return this.countField;
        }
        set {
            this.countField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}