<!-- <script setup>
  import Home from './components/HomePage.vue'
</script>
<template>
  <home />
</template> -->


<!--  -->
<template>
  <div class="container mt-5">
    <h1 class="text-center mb-4">GitHub Repositories</h1>
    <div class="row">
      <div class="col-md-6" v-for="repo in repositories" :key="repo.id">
        <div class="card mb-4">
          <div class="card-body">
            <h5 class="card-title">{{ repo.name }}</h5>
            <p class="card-text">{{ repo.description }}</p>
            <p class="card-text">
              <small class="text-muted">
                Stars: {{ repo.stars }} | Owner: {{ repo.ownerUsername }}
              </small>
            </p>
            <button
              class="btn btn-primary"
              @click="viewDetails(repo)"
            >
              View Details
            </button>
          </div>
        </div>
      </div>
    </div>

    <!-- Modal for details -->
    <div
      class="modal fade"
      id="detailsModal"
      tabindex="-1"
      aria-hidden="true"
      ref="detailsModal"
    >
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">{{ selectedRepo.name }}</h5>
            <button
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
            ></button>
          </div>
          <div class="modal-body">
            <p><strong>Description:</strong> {{ selectedRepo.description }}</p>
            <p><strong>Owner:</strong> {{ selectedRepo.ownerUsername }}</p>
            <p><strong>Stars:</strong> {{ selectedRepo.stars }}</p>
            <p><strong>Created Date:</strong> {{ selectedRepo.createdDate }}</p>
            <p><strong>Last Push Date:</strong> {{ selectedRepo.lastPushDate }}</p>
            <a :href="selectedRepo.url" target="_blank">View on GitHub</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      repositories: [],
      selectedRepo: {}
    };
  },
  methods: {
    async fetchRepositories() {
      try {
        // const response = await axios.get("http://localhost:5001/api/repositories"); 
        // const response = await axios.get("http://localhost:5173/api/repositories"); 
        const response = await axios.get("http://localhost:5278/api/repositories"); 
        this.repositories = response.data;
      } catch (error) {
        console.error("Error fetching repositories:", error);
      }
    },
    viewDetails(repo) {
      this.selectedRepo = repo;
      const modal = new bootstrap.Modal(this.$refs.detailsModal);
      modal.show();
    }
  },
  mounted() {
    this.fetchRepositories();
  }
};
</script>

<style>
/* Optional: Add custom styling */
</style>
