using System.Collections.Frozen;

namespace MinimalTelegramBot.Localization;

/// <inheritdoc />
internal sealed class LocaleStringSetBuilder : ILocaleStringSetBuilder
{
    private readonly List<IReadOnlyDictionary<string, string>> _values = [];

    public LocaleStringSetBuilder(Locale locale)
    {
        Locale = locale;
    }

    /// <inheritdoc />
    public Locale Locale { get; }

    /// <inheritdoc />
    public LocaleStringSet Build()
    {
        var combined = _values.SelectMany(x => x).ToFrozenDictionary();
        return new LocaleStringSet
        {
            Locale = Locale,
            Values = combined,
        };
    }

    /// <inheritdoc />
    public ILocaleStringSetBuilder Enrich(IReadOnlyDictionary<string, string> stringSet)
    {
        _values.Add(stringSet);
        return this;
    }
}
