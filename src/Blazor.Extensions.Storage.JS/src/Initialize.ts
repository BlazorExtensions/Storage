import './GlobalExports';
// Declare types here until we've Blazor.d.ts
export interface System_Object { System_Object__DO_NOT_IMPLEMENT: any };
export interface System_String extends System_Object { System_String__DO_NOT_IMPLEMENT: any }

interface Platform {
  toJavaScriptString(dotNetString: System_String): string;
}

type BlazorType = {
  registerFunction(identifier: string, implementation: Function),
  platform: Platform
};

const Blazor: BlazorType = window["Blazor"];

function initialize() {
  "use strict";

  Blazor.registerFunction('Blazor.Extensions.Storage.Length', (storage: string) => {
    return window[storage].length;
  });

  Blazor.registerFunction('Blazor.Extensions.Storage.Key', (storage: string, index: number) => {
    return window[storage].key(index);
  });

  Blazor.registerFunction('Blazor.Extensions.Storage.GetItem', (storage: string, key: string) => {
    let item = window[storage].getItem(key);
    if (item)
    {
      return JSON.parse(item);
    }
    return null;
  });

  Blazor.registerFunction('Blazor.Extensions.Storage.SetItem', (storage: string, key: string, keyValue: string) => {
    window[storage].setItem(key, keyValue);
  });

  Blazor.registerFunction('Blazor.Extensions.Storage.RemoveItem', (storage: System_String, key: System_String) => {
    window[Blazor.platform.toJavaScriptString(storage)].removeItem(Blazor.platform.toJavaScriptString(key));
  });

  Blazor.registerFunction('Blazor.Extensions.Storage.Clear', (storage: System_String) => {
    window[Blazor.platform.toJavaScriptString(storage)].clear();
  });
}

initialize();
