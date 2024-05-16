<script setup lang="ts">
import { ref, onMounted } from "vue";
import {ToShortDate} from "@/common/formatters";
import {useRoute} from "vue-router";

type LegalContract = {
  id: string,
  author: string,
  legalEntity: string,
  contract: string,
  createdAt: string,
  updatedAt: string
};

let legalContract = ref({} as LegalContract);

const id = useRoute().params.id;
onMounted(() => {
  fetchData();
});

function fetchData(): void {
  fetch('legalcontracts/' + id, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'X-Content-Type-Options': 'nosniff',
    }
  })
      .then(r => r.json())
      .then(json => {
        legalContract.value = json as LegalContract;
        return;
      });
}
</script>

<template>
<h3>Legal contract details {{}}</h3>
<div class="border">
  <dl class="row">
    <dt class="col-sm-3">Author: </dt>
    <dd class="col-sm-9">{{ legalContract.author }}</dd>

    <dt class="col-sm-3">Legal entity: </dt>
    <dd class="col-sm-9">
      <p>{{ legalContract.legalEntity }}</p>
    </dd>

    <dt class="col-sm-3">Contract description: </dt>
    <dd class="col-sm-9">{{ legalContract.contract }}</dd>

    <dt class="col-sm-3">Auditing: </dt>
    <dd class="col-sm-9">
      <dl class="row">
        <dt class="col-sm-4">Created on: </dt>
        <dd class="col-sm-8">{{ ToShortDate(legalContract.createdAt) }}</dd>
        
          <dt v-if="legalContract.updatedAt" class="col-sm-4">Last updated on: </dt>
          <dd v-if="legalContract.updatedAt" class="col-sm-8">{{ ToShortDate(legalContract.updatedAt) }}</dd>
      </dl>
    </dd>
  </dl>
  </div>
  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
    <div class="btn-group mr-2" role="group" aria-label="Second group">
      <button type="submit" class="btn btn-info breathing-space">
        <router-link to="/list" class="nav-link nav-link-button">Back to List</router-link>
      </button>
    </div>
  </div>
</template>

<style scoped>
.border {
  border: 1px solid #e0e0e0;
  padding: 10px;
  margin-top: 10px;
}
.btn-toolbar {
  display: flex;
  justify-content: right;
  padding-right: 2em;
}
.nav-link-button {
  color: white;
}
.breathing-space {
  margin: 1em;
}
</style>