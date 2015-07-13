# AutoSuggest

Simple library that offers auto suggest functionality. Quite runtime and space efficient due to the prefix tree based implementation.

There are two ways to get the underlying dictionary populated.

## Load dictionary from file

The dictionary file should contain one word per file. Users on *nix can use `cat /usr/share/dict/words > words.txt` for most english words.

```
ISuggestWords suggester = SuggesterBuilder.Build("path to dictionary");
var suggestedWords = suggester.Suggest("access");
```

## Own implementation of `ILoadDictionary`

```
ILoadDictionary customDictionaryLoader = ...
ISuggestWords suggester = SuggesterBuilder.Build(customDictionaryLoader);
var suggestedWords = suggester.Suggest("access");
```
