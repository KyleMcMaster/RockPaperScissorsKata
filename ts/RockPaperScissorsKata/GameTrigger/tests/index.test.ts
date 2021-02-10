//import { expect } from 'chai';
import {
  createHttpTrigger,
  runStubFunctionFromBindings,
} from 'stub-azure-function-context';

import httpTrigger from '../index';

jest.mock("node-fetch");

describe("game trigger run", () => {
  it("returns 200", async () => {
    const context = await runStubFunctionFromBindings(
      httpTrigger,
      [
        {
          type: "httpTrigger",
          name: "req",
          direction: "in",
            data: createHttpTrigger(
              "GET",
              "http://slowdeck.io",
              {},
              {},
              {name: "jdawg"},
              {}
            ),
        },
        { type: "http", name: "res", direction: "out" },
      ],
      new Date()
    );

    console.log(JSON.stringify(context));

    expect(context.res.body).toEqual("Hello, jdawg. This HTTP triggered function executed successfully.");
  });
});
