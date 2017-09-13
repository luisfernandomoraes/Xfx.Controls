﻿using System;
using Xamarin.Forms;

namespace Xfx
{
	public class XfxEntry : Entry
	{
		public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(nameof(ErrorText),
			typeof(string),
			typeof(XfxEntry),
			default(string), propertyChanged: OnErrorTextChangedInternal);

		public static readonly BindableProperty FloatingHintEnabledProperty = BindableProperty.Create(nameof(FloatingHintEnabled),
			typeof(bool),
			typeof(XfxEntry),
			true);

		public Color BottomLineColor
		{
			get => (Color)GetValue(BottomLineColorProperty);
			set => SetValue(BottomLineColorProperty, value);
		}

		private readonly BindableProperty BottomLineColorProperty = BindableProperty.Create(nameof(BottomLineColor), typeof(Color), typeof(XfxEntry), Color.Black);

		public int MaxLenght
		{
			get => (int)GetValue(MaxLenghtProperty);
			set => SetValue(MaxLenghtProperty, value);
		}

		private readonly BindableProperty MaxLenghtProperty = BindableProperty.Create(nameof(MaxLenght), typeof(int), typeof(XfxEntry), int.MaxValue);

		/// <summary>
		/// <c>true</c> to float the hint into a label, otherwise <c>false</c>. This is a bindable property.
		/// </summary>
		public bool FloatingHintEnabled
		{
			get { return (bool)GetValue(FloatingHintEnabledProperty); }
			set { SetValue(FloatingHintEnabledProperty, value); }
		}

		/// <summary>
		///    Error text for the entry. An empty string removes the error. This is a bindable property.
		/// </summary>
		public string ErrorText
		{
			get { return (string)GetValue(ErrorTextProperty); }
			set { SetValue(ErrorTextProperty, value); }
		}

		/// <summary>
		/// Raised when the value of the error text changes
		/// </summary>
		public event EventHandler<TextChangedEventArgs> ErrorTextChanged;

		private static void OnErrorTextChangedInternal(BindableObject bindable, object oldvalue, object newvalue)
		{
			var materialEntry = (XfxEntry)bindable;
			materialEntry.OnErrorTextChanged(bindable, oldvalue, newvalue);
			materialEntry.ErrorTextChanged?.Invoke(materialEntry, new TextChangedEventArgs((string)oldvalue, (string)newvalue));
		}

		protected virtual void OnErrorTextChanged(BindableObject bindable, object oldvalue, object newvalue) { }
	}
}