const blazorExtensions = 'BlazorExtensions';

interface IBrowserStorage {
  Length(storage: string): number;
  Key(storage: string, index: number): any;
  GetItem(storage: string, key: string): any;
  SetItem(storage: string, key: string, keyValue: string): void;
  RemoveItem(storage: string, key: string): void;
  Clear(storage: string): void;
};

class BrowserStorage implements IBrowserStorage {
  public Length(storage: string): number {
    return window[storage].length;
  };

  public Key(storage: string, index: number): any {
    return window[storage].key(index);
  };

  public GetItem(storage: string, key: string): any {
    let item = window[storage].getItem(key);
    if (item) {
      // HACK: While we wait for https://github.com/aspnet/Blazor/issues/1205 to be fixed we just send back a string and deserialize it in C# land
      return item;
      //return JSON.parse(item);
    }

    return null;
  };

  public SetItem(storage: string, key: string, keyValue: string): void {
    window[storage].setItem(key, keyValue);
  };

  public RemoveItem(storage: string, key: string): void {
    window[storage].removeItem(key);
  };

  Clear(storage: string): void {
    window[storage].clear();
  };
};


function initialize() {
  "use strict";

  if (typeof window !== 'undefined' && !window[blazorExtensions]) {
    // When the library is loaded in a browser via a <script> element, make the
    // following APIs available in global scope for invocation from JS
    window[blazorExtensions] = {
      Storage: new BrowserStorage()
    };
  } else {
    window[blazorExtensions] = {
      ...window[blazorExtensions],
      Storage: new BrowserStorage()
    };
  }
}

initialize();
