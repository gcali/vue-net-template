import Vue from 'vue'

export const store = Vue.observable({
  user: undefined as undefined | string,
  loading: 0 as number,
});
