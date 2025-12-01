#!/usr/bin/env bun
// Bun js version just for reference

import { readFile } from "node:fs/promises";

export function part1(lines) {
  // TODO: implement part 1 logic
  return lines[0];
}

export function part2(lines) {
  // TODO: implement part 2 logic
  return lines[0];
}

// ------------------------------
// Helpers
// ------------------------------

async function readLines(path) {
  try {
    const data = await readFile(path, "utf8");
    return data
      .replace(/\r/g, "")
      .split("\n")
      .filter((x) => x.length > 0);
  } catch {
    return null;
  }
}

async function runDay() {
  const day = 1;
  console.log(`\n--- Day ${day} ---\n`);

  // ----- Example Input -----
  const examplePath = `./inputs/day_${day}_example.txt`;
  const exampleLines = await readLines(examplePath);

  if (exampleLines === null) {
    console.warn("Example input is missing");
  } else {
    try {
      console.log(`Part 1 Example: ${part1(exampleLines)}`);
      console.log(`Part 2 Example: ${part2(exampleLines)}`);
    } catch (err) {
      console.error(`Error in Example: ${err.message}`);
    }
  }

  // ----- Actual Input -----
  const inputPath = `./inputs/day_${day}_input.txt`;
  const inputLines = await readLines(inputPath);

  if (inputLines === null) {
    console.warn("Actual input is missing");
  } else {
    try {
      console.log(`Part 1: ${part1(inputLines)}`);
      console.log(`Part 2: ${part2(inputLines)}`);
    } catch (err) {
      console.error(`Error in Actual Input: ${err.message}`);
    }
  }
}

runDay();
