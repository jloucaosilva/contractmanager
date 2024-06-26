/* eslint-env node */
require('@rushstack/eslint-patch/modern-module-resolution');

module.exports = {
  root: true,
  'extends': [
    'plugin:vue/vue3-essential',
    'eslint:recommended',
    '@vue/eslint-config-typescript',
  ],
  parserOptions: {
    ecmaVersion: 'latest',
  },
  rules: {
    'linebreak-style': 0,
    'comma-dangle': ['error', 'always-multiline'],
    'semi': ['error', 'always'],
    'operator-linebreak': 0,
  },
  env: {
    node: true,
    'vue/setup-compiler-macros': true,
  },
};
