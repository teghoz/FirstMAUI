﻿using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace FirstMaui.Controls.ProgressBar;
public class ProgressBar : SKCanvasView
{
    private SKCanvas _canvas;
    private SKRect _drawRect;
    private SKImageInfo _info;

    public float Progress
    {
        get => (float)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value);
    }

    public Color ProgressColor
    {
        get => (Color)GetValue(ProgressColorProperty);
        set => SetValue(ProgressColorProperty, value);
    }

    public Color GradientColor
    {
        get => (Color)GetValue(GradientColorProperty);
        set => SetValue(GradientColorProperty, value);
    }

    public Color BaseColor
    {
        get => (Color)GetValue(BaseColorProperty);
        set => SetValue(BaseColorProperty, value);
    }

    public bool UseRange
    {
        get => (bool)GetValue(UseRangeProperty);
        set => SetValue(UseRangeProperty, value);
    }

    public float LowerRangeValue
    {
        get => (float)GetValue(LowerRangeValueProperty);
        set => SetValue(LowerRangeValueProperty, value);
    }

    public float UpperRangeValue
    {
        get => (float)GetValue(UpperRangeValueProperty);
        set => SetValue(UpperRangeValueProperty, value);
    }

    public bool UseGradient
    {
        get => (bool)GetValue(UseGradientProperty);
        set => SetValue(UseGradientProperty, value);
    }

    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(float), typeof(ProgressBar), 0.0f, propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(ProgressBar), Color.FromArgb("#8a2be2"), propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty GradientColorProperty = BindableProperty.Create(nameof(GradientColor), typeof(Color), typeof(ProgressBar), Color.FromArgb("#8a2be2"), propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty BaseColorProperty = BindableProperty.Create(nameof(BaseColor), typeof(Color), typeof(ProgressBar), Color.FromArgb("#728589"), propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty UseRangeProperty = BindableProperty.Create(nameof(UseRange), typeof(bool), typeof(ProgressBar), false, propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty LowerRangeValueProperty = BindableProperty.Create(nameof(LowerRangeValue), typeof(float), typeof(ProgressBar), 0.0f, propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty UpperRangeValueProperty = BindableProperty.Create(nameof(UpperRangeValue), typeof(float), typeof(ProgressBar), 0.0f, propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty UseGradientProperty = BindableProperty.Create(nameof(UseGradient), typeof(bool), typeof(ProgressBar), false, propertyChanged: OnBindablePropertyChanged);

    private static void OnBindablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((ProgressBar)bindable).InvalidateSurface();
    }

    public ProgressBar()
    {
        IgnorePixelScaling = false;
    }

    protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        base.OnPaintSurface(e);

        _canvas = e.Surface.Canvas;
        _canvas.Clear();

        _info = e.Info;

        _drawRect = new SKRect(0, 0, _info.Width, _info.Height);

        DrawBase();
        DrawProgress();
    }

    private void DrawBase()
    {
        using var basePath = new SKPath();
        basePath.AddRect(_drawRect);
        _canvas.DrawPath(basePath, new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = BaseColor.ToSKColor(),
            IsAntialias = true
        });
    }

    private void DrawProgress()
    {
        using var progressPath = new SKPath();

        var progressRect = UseRange
            ? new SKRect(_info.Width * LowerRangeValue, 0, _info.Width * UpperRangeValue, _info.Height)
            : new SKRect(0, 0, _info.Width * Progress, _info.Height);

        progressPath.AddRect(progressRect);

        using var progressPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            IsAntialias = true
        };

        if (UseGradient)
        {
            progressPaint.Shader = SKShader.CreateLinearGradient(
                new SKPoint(_drawRect.Left, _drawRect.MidY),
                new SKPoint(_drawRect.Right, _drawRect.MidY),
                new[] { GradientColor.ToSKColor(), ProgressColor.ToSKColor() },
                new[] { 0.0f, 1.0f },
                SKShaderTileMode.Clamp
            );
        }
        else
        {
            progressPaint.Color = ProgressColor.ToSKColor();
        }

        _canvas.DrawPath(progressPath, progressPaint);
    }
}
