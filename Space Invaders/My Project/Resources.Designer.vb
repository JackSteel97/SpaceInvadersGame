﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34014
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Space_Invaders.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
		End Property
		Friend ReadOnly Property joel_the_spanner() As System.Drawing.Bitmap
			Get
				Dim obj As Object = ResourceManager.GetObject("joel_the_spanner", resourceCulture)
				Return CType(obj, System.Drawing.Bitmap)
			End Get
		End Property
		Friend ReadOnly Property invaderkilled() As System.IO.UnmanagedMemoryStream
			Get
				Return ResourceManager.GetStream("invaderkilled", resourceCulture)
			End Get
		End Property
		Friend ReadOnly Property ufo_lowpitch() As System.IO.UnmanagedMemoryStream
			Get
				Return ResourceManager.GetStream("ufo_lowpitch", resourceCulture)
			End Get
		End Property

		Friend ReadOnly Property shoot() As System.IO.UnmanagedMemoryStream
			Get
				Return ResourceManager.GetStream("shoot", resourceCulture)
			End Get
		End Property
		Friend ReadOnly Property explosion() As System.IO.UnmanagedMemoryStream
			Get
				Return ResourceManager.GetStream("explosion", resourceCulture)
			End Get
		End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
		End Property
		Friend ReadOnly Property ship() As System.Drawing.Bitmap
			Get
				Dim obj As Object = ResourceManager.GetObject("ship", resourceCulture)
				Return CType(obj, System.Drawing.Bitmap)
			End Get
		End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property carlosadiaz644presents_SPACE_INVADERS_OFFICIAL_THE() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("carlosadiaz644presents_SPACE_INVADERS_OFFICIAL_THE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Fire_Explosion_PNG_Picture_Clipart() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Fire_Explosion_PNG_Picture_Clipart", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property galagaship2() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("galagaship2", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property invaderpos2() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("invaderpos2", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property missilepowerup() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("missilepowerup", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property shield() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("shield", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
		End Property
		Friend ReadOnly Property UFO() As System.Drawing.Bitmap
			Get
				Dim obj As Object = ResourceManager.GetObject("UFO", resourceCulture)
				Return CType(obj, System.Drawing.Bitmap)
			End Get
		End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property shieldhit() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("shieldhit", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
		Friend ReadOnly Property space_invadertrans() As System.Drawing.Bitmap
			Get
				Dim obj As Object = ResourceManager.GetObject("space_invadertrans", resourceCulture)
				Return CType(obj, System.Drawing.Bitmap)
			End Get
		End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property SpeedPowerup() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("SpeedPowerup", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
